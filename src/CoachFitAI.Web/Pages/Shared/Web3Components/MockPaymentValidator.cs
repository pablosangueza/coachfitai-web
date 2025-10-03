using System;
using System.Threading;
using System.Threading.Tasks;
using CoachFitAI.Shared.Web3Components;

namespace CoachFitAI.Web.Pages.Shared.Web3Components
{
    public enum MockPaymentResultMode { Confirm, Fail, Timeout }

    public class MockPaymentValidator : IPaymentValidator
    {
        private readonly MockPaymentResultMode _mode;
        private readonly TimeSpan _simulateDelay;
        private readonly decimal _amount;
        private readonly string _from;
        private readonly string _to;
        private readonly string _txHash;

        public MockPaymentValidator(
            MockPaymentResultMode mode = MockPaymentResultMode.Confirm,
            TimeSpan? simulateDelay = null,
            decimal amount = 1m,
            string from = "0xfrom",
            string to = "0xto",
            string txHash = "0xtxhash")
        {
            _mode = mode;
            _simulateDelay = simulateDelay ?? TimeSpan.FromSeconds(2);
            _amount = amount;
            _from = from;
            _to = to;
            _txHash = txHash;
        }

        public async Task<PaymentResult> WaitForPaymentAsync(PaymentRequest request, TimeSpan timeout, CancellationToken ct = default)
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.CancelAfter(timeout);

            try
            {
                await Task.Delay(_simulateDelay, cts.Token);

                return _mode switch
                {
                    MockPaymentResultMode.Confirm => new PaymentResult(
                        State: PaymentState.Confirmed,
                        TransactionHash: _txHash,
                        Amount: _amount,
                        From: _from,
                        To: _to,
                        Message: "Mock payment confirmed"
                    ),
                    MockPaymentResultMode.Fail => new PaymentResult(
                        State: PaymentState.Failed,
                        Message: "Mocked failure validating payment"
                    ),
                    _ => new PaymentResult(
                        State: PaymentState.Timeout,
                        Message: "Mocked timeout waiting payment"
                    )
                };
            }
            catch (OperationCanceledException)
            {
                return new PaymentResult(PaymentState.Timeout, Message: "Mocked timeout / cancelled");
            }
            catch (Exception ex)
            {
                return new PaymentResult(PaymentState.Failed, Message: $"Mock validator error: {ex.Message}");
            }
        }
    }
}