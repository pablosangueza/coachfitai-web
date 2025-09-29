using CoachFitAI.Web.State;
namespace CoachFitAI.Web.Services.Mock;

public class MockPlanService : IPlanService
{
    public Task<PlanDto> GeneratePlanAsync(IntakeDto i)
    {
        var plan = new PlanDto
        {
            CaloriesPerDay = (2000, 2200),
            Macros = (160, 220, 70),
            WeeklyPlan = new[]
            {
                new DayNutritionDto
                {
                    Day = "Monday",
                    Meals = new[]
                    {
                        new MealDto
                        {
                            Name = "Oats + Whey",
                            Ingredients = new[]
                            {
                                new IngredientDto { Item = "Oats", Grams = 80 },
                                new IngredientDto { Item = "Milk", Grams = 250 },
                                new IngredientDto { Item = "Whey", Grams = 30 }
                            },
                            Kcal = 520
                        }
                    }
                }
            },
            ShoppingList = new[]
            {
                new ShoppingItemDto { Item = "Oats", Quantity = "600 g" }
            },
            DaysPerWeek = 5,
            Sessions = new[]
            {
                new SessionDto
                {
                    Day = "Monday",
                    Focus = "Push",
                    Exercises = new[]
                    {
                        new ExerciseDto
                        {
                            Name = "Bench Press",
                            Sets = 4,
                            Reps = "6-8",
                            Intensity = "RPE 7"
                        }
                    },
                    DurationMin = 60
                }
            },
            Assumptions = new[] { "Assumed moderate daily activity" },
            Warnings = new[] { "This is not medical advice" },
            Summary = "Balanced plan to lose fat while keeping muscle."
        };

        return Task.FromResult(plan);
    }
}
