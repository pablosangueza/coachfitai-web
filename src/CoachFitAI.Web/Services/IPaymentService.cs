using System;
using System.Threading;
using System.Threading.Tasks;
using CoachFitAI.Web.State;

namespace CoachFitAI.Web.Services;
public interface IPaymentService
{
    Task<OrderDto> StartCheckoutAsync(decimal amountUsd);
    Task<bool> ConfirmPaymentAsync(Guid orderId);
    Task SubscribeToWebhookAsync(Guid orderId, Func<OrderStatusUpdateDto, Task> onUpdate, CancellationToken cancellationToken = default);
}
