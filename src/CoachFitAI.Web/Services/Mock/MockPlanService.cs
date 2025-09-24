using CoachFitAI.Web.State;
namespace CoachFitAI.Web.Services.Mock;

public class MockPlanService : IPlanService
{
    public Task<PlanDto> GeneratePlanAsync(IntakeDto i)
    {
        var plan = new PlanDto(
            (2000, 2200),
            (160, 220, 70),
            new[] {
              new DayNutritionDto("Monday",
                new[] { new MealDto("Oats + Whey",
                  new[] { new IngredientDto("Oats",80), new IngredientDto("Milk",250), new IngredientDto("Whey",30)}, 520) })
            },
            new[] { new ShoppingItemDto("Oats","600 g") },
            5,
            new[] { new SessionDto("Monday","Push", new[]{ new ExerciseDto("Bench Press",4,"6-8","RPE 7") },60) },
            new[] { "Assumed moderate daily activity" },
            new[] { "This is not medical advice" },
            "Balanced plan to lose fat while keeping muscle."
        );
        return Task.FromResult(plan);
    }
}
