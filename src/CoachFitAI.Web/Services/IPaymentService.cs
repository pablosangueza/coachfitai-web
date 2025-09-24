using CoachFitAI.Web.State;
namespace CoachFitAI.Web.Services;
public interface IPaymentService
{
    Task<OrderDto> StartCheckoutAsync(decimal amountUsd);
    Task<bool> ConfirmPaymentAsync(Guid orderId);
}
