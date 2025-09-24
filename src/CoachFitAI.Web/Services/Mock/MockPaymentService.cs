using CoachFitAI.Web.State;
namespace CoachFitAI.Web.Services.Mock;

public class MockPaymentService : IPaymentService
{
    public Task<OrderDto> StartCheckoutAsync(decimal amountUsd)
        => Task.FromResult(new OrderDto(Guid.NewGuid(), amountUsd, "USD", "mock", "pending"));

    public Task<bool> ConfirmPaymentAsync(Guid orderId) => Task.FromResult(true);
}
