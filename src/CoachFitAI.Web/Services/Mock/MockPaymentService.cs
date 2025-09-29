using CoachFitAI.Web.State;
namespace CoachFitAI.Web.Services.Mock;

public class MockPaymentService : IPaymentService
{
    public Task<OrderDto> StartCheckoutAsync(decimal amountUsd)
        => Task.FromResult(new OrderDto
        {
            Id = Guid.NewGuid(),
            Amount = amountUsd,
            Currency = "USD",
            Provider = "mock",
            Status = "pending"
        });

    public Task<bool> ConfirmPaymentAsync(Guid orderId) => Task.FromResult(true);
}
