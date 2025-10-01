using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using CoachFitAI.Shared.Web3Components;
using Nethereum.Contracts.Standards.ENS.ENSRegistry.ContractDefinition;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;

namespace CoachFitAI.Web.Pages.Shared.Web3Components
{
   public interface IPaymentValidator
{
    Task<PaymentResult> WaitForPaymentAsync(
        PaymentRequest request,
        TimeSpan timeout,
        CancellationToken ct = default);
}

public class EvmPaymentValidator : IPaymentValidator
{
    public async Task<PaymentResult> WaitForPaymentAsync(
        PaymentRequest req,
        TimeSpan timeout,
        CancellationToken ct = default)
    {
        try
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.CancelAfter(timeout);

            var web3 = new Web3(req.RpcUrl);

            // Normaliza direcciones (checksum)
            var toChecksum = new AddressUtil();
            var merchant = toChecksum.ConvertToChecksumAddress(req.MerchantAddress);
            var token = toChecksum.ConvertToChecksumAddress(req.TokenContract);

            // Obtiene decimales del token para convertir montos
            var erc20 = web3.Eth.ERC20.GetContractService(token);
            var decimals = (int)(await erc20.DecimalsQueryAsync());
            var unitFactor = BigInteger.Pow(10, decimals);
            var expectedRaw = new BigInteger(req.ExpectedAmount * (decimal)BigInteger.Pow(10, decimals));

            // Rango de búsqueda inicial (pasados y futuros)
            var latestBlock = (ulong)(await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync()).Value;
            var fromBlock = latestBlock > req.LookbackBlocks ? latestBlock - req.LookbackBlocks : 0UL;

            var transferEvent = web3.Eth.GetEvent<TransferEventDTO>(token);

            // Filtro: hacia merchant
           var filterInput = transferEvent.CreateFilterInput(
                new BlockParameter(fromBlock),
                BlockParameter.CreateLatest(),
                new object[] { null, merchant }
            );

            // Polling hasta timeout/confirmación
            while (!cts.IsCancellationRequested)
            {
                // 1) Revisa logs de Transfer (históricos hasta latest)
                var changes = await transferEvent.GetAllChangesAsync(filterInput);

                foreach (var ev in changes)
                {
                    // Verifica monto exacto
                    if (ev.Event.To.Equals(merchant, StringComparison.OrdinalIgnoreCase) &&
                        ev.Event.Value == expectedRaw)
                    {
                        // 2) Espera confirmaciones
                        var txHash = ev.Log.TransactionHash;
                        var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(txHash);
                        if (receipt == null || receipt.BlockNumber == null)
                            continue;

                        var txBlock = (ulong)receipt.BlockNumber.Value;
                        var current = (ulong)(await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync()).Value;

                        var confirmed = current >= txBlock + req.ConfirmationsRequired;
                        if (confirmed)
                        {
                            // Convierte a unidades humanas
                            var amountHuman = (decimal)ev.Event.Value / (decimal)unitFactor;

                            return new PaymentResult(
                                State: PaymentState.Confirmed,
                                TransactionHash: txHash,
                                Amount: amountHuman,
                                From: ev.Event.From,
                                To: ev.Event.To,
                                Message: $"Pago confirmado con {req.ConfirmationsRequired}+ confirmaciones."
                            );
                        }
                    }
                }

                // 3) Pequeña espera antes del siguiente ciclo
                await Task.Delay(TimeSpan.FromSeconds(6), cts.Token);

                // Actualiza latest block para futuras confirmaciones
                latestBlock = (ulong)(await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync()).Value;

                // Ajusta tope superior del filtro a latest dinámicamente
                filterInput.ToBlock = new BlockParameter(latestBlock);
            }

            return new PaymentResult(PaymentState.Timeout, Message: "Tiempo agotado esperando el pago.");
        }
        catch (OperationCanceledException)
        {
            return new PaymentResult(PaymentState.Timeout, Message: "Cancelado/timeout esperando el pago.");
        }
        catch (Exception ex)
        {
            return new PaymentResult(PaymentState.Failed, Message: $"Error validando pago: {ex.Message}");
        }
    }
}
}