using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoachFitAI.Web.State;

namespace CoachFitAI.Web.Services.Mock;

public class MockPaymentService : IPaymentService
{
    private readonly ConcurrentDictionary<Guid, OrderDto> _orders = new();

    public Task<OrderDto> StartCheckoutAsync(decimal amountUsd)
    {
        var order = new OrderDto
        {
            Id = Guid.NewGuid(),
            Amount = amountUsd,
            Currency = "USD",
            Provider = "mock-crypto",
            Status = "pending",
            Wallets = new List<CryptoWalletDto>
            {
                new()
                {
                    Symbol = "USDT",
                    Network = "TRON (TRC20)",
                    Address = "TK1MockAddress1234567890",
                    Note = "Stablecoin deposit address"
                },
                new()
                {
                    Symbol = "USDC",
                    Network = "Ethereum (ERC20)",
                    Address = "0xMockAddress1234567890ABCDEF",
                    Note = "Gas fees apply on Ethereum"
                }
            }
        };

        _orders[order.Id] = order;
        return Task.FromResult(order);
    }

    public Task<bool> ConfirmPaymentAsync(Guid orderId)
    {
        if (_orders.TryGetValue(orderId, out var order) &&
            string.Equals(order.Status, "confirmed", StringComparison.OrdinalIgnoreCase))
        {
            order.Status = "fulfilled";
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }

    public Task SubscribeToWebhookAsync(Guid orderId, Func<OrderStatusUpdateDto, Task> onUpdate, CancellationToken cancellationToken = default)
    {
        if (!_orders.TryGetValue(orderId, out var order))
        {
            return Task.CompletedTask;
        }

        return Task.Run(async () =>
        {
            await onUpdate(new OrderStatusUpdateDto
            {
                OrderId = order.Id,
                Status = order.Status,
                Message = "Waiting for stablecoin transfer."
            });

            try
            {
                await Task.Delay(TimeSpan.FromSeconds(6), cancellationToken);
            }
            catch (TaskCanceledException)
            {
                return;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            order.Status = "confirmed";

            await onUpdate(new OrderStatusUpdateDto
            {
                OrderId = order.Id,
                Status = order.Status,
                Message = "Mock webhook: payment detected and confirmed.",
                TransactionHash = Guid.NewGuid().ToString("N")
            });
        }, cancellationToken);
    }
}
