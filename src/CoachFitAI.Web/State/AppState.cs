namespace CoachFitAI.Web.State;

public class AppState
{
    public IntakeDto? Intake { get; private set; }
    public OrderDto? Order { get; private set; }
    public PlanDto? Plan { get; private set; }

    public void SetIntake(IntakeDto v) => Intake = v;
    public void SetOrder(OrderDto v) => Order = v;
    public void SetPlan(PlanDto v) => Plan = v;
    public void Reset() { Intake = null; Order = null; Plan = null; }
}
