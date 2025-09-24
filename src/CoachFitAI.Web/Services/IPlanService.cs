using CoachFitAI.Web.State;
namespace CoachFitAI.Web.Services;
public interface IPlanService
{
    Task<PlanDto> GeneratePlanAsync(IntakeDto intake);
}
