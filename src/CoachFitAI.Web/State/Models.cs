using System;
using System.Collections.Generic;

namespace CoachFitAI.Web.State;

public class IntakeDto
{
    public string Gender { get; set; } = string.Empty;
    public int Age { get; set; }
    public double WeightKg { get; set; }
    public double HeightCm { get; set; }
    public string Goal { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public string BodyType { get; set; } = string.Empty;
    public string[] Restrictions { get; set; } = Array.Empty<string>();
    public string DailyActivity { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; }
    public string Email { get; set; } = string.Empty;
}

public class OrderDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

public class IngredientDto
{
    public string Item { get; set; } = string.Empty;
    public int Grams { get; set; }
}

public class MealDto
{
    public string Name { get; set; } = string.Empty;
    public IEnumerable<IngredientDto> Ingredients { get; set; } = Array.Empty<IngredientDto>();
    public int Kcal { get; set; }
}

public class DayNutritionDto
{
    public string Day { get; set; } = string.Empty;
    public IEnumerable<MealDto> Meals { get; set; } = Array.Empty<MealDto>();
}

public class ShoppingItemDto
{
    public string Item { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
}

public class ExerciseDto
{
    public string Name { get; set; } = string.Empty;
    public int Sets { get; set; }
    public string Reps { get; set; } = string.Empty;
    public string Intensity { get; set; } = string.Empty;
}

public class SessionDto
{
    public string Day { get; set; } = string.Empty;
    public string Focus { get; set; } = string.Empty;
    public IEnumerable<ExerciseDto> Exercises { get; set; } = Array.Empty<ExerciseDto>();
    public int DurationMin { get; set; }
}

public class PlanDto
{
    public (int Min, int Max) CaloriesPerDay { get; set; }
    public (int Protein_g, int Carbs_g, int Fat_g) Macros { get; set; }
    public IEnumerable<DayNutritionDto> WeeklyPlan { get; set; } = Array.Empty<DayNutritionDto>();
    public IEnumerable<ShoppingItemDto> ShoppingList { get; set; } = Array.Empty<ShoppingItemDto>();
    public int DaysPerWeek { get; set; }
    public IEnumerable<SessionDto> Sessions { get; set; } = Array.Empty<SessionDto>();
    public string[] Assumptions { get; set; } = Array.Empty<string>();
    public string[] Warnings { get; set; } = Array.Empty<string>();
    public string Summary { get; set; } = string.Empty;
}
