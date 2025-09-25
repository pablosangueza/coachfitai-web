namespace CoachFitAI.Web.State;

public record IntakeDto(
    string Gender, int Age, double WeightKg, double HeightCm,
    string Goal, string Level, string BodyType,
    string[] Restrictions, string DailyActivity, string? PhotoUrl);
    

public record OrderDto(Guid Id, decimal Amount, string Currency, string Provider, string Status);

public record IngredientDto(string Item, int Grams);
public record MealDto(string Name, IEnumerable<IngredientDto> Ingredients, int Kcal);
public record DayNutritionDto(string Day, IEnumerable<MealDto> Meals);
public record ShoppingItemDto(string Item, string Quantity);
public record ExerciseDto(string Name, int Sets, string Reps, string Intensity);
public record SessionDto(string Day, string Focus, IEnumerable<ExerciseDto> Exercises, int DurationMin);

public record PlanDto(
    (int Min, int Max) CaloriesPerDay,
    (int Protein_g, int Carbs_g, int Fat_g) Macros,
    IEnumerable<DayNutritionDto> WeeklyPlan,
    IEnumerable<ShoppingItemDto> ShoppingList,
    int DaysPerWeek,
    IEnumerable<SessionDto> Sessions,
    string[] Assumptions,
    string[] Warnings,
    string Summary);
