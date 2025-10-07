using CoachFitAI.Web.State;
namespace CoachFitAI.Web.Services.Mock;

public class MockPlanService : IPlanService
{
    public Task<PlanDto> GeneratePlanAsync(IntakeDto i)
    {
        var plan = new PlanDto
        {
            CaloriesPerDay = (1800, 2200),
            Macros = (Protein_g: 150, Carbs_g: 220, Fat_g: 65),
            DaysPerWeek = 5,
            Summary = $"Mock weekly plan for {i.Gender}, {i.Age} y/o, goal: {i.Goal}",

            WeeklyPlan = new[]
            {
                new DayNutritionDto
                {
                    Day = "Monday",
                    Meals = new[]
                    {
                        new MealDto { Name = "Breakfast", Kcal = 450, Ingredients = new[]{ new IngredientDto{ Item="Oats", Grams=70 }, new IngredientDto{ Item="Banana", Grams=120 }, new IngredientDto{ Item="Whey", Grams=30 } } },
                        new MealDto { Name = "Snack", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Greek Yogurt", Grams=150 } } },
                        new MealDto { Name = "Lunch", Kcal = 650, Ingredients = new[]{ new IngredientDto{ Item="Chicken Breast", Grams=200 }, new IngredientDto{ Item="Brown Rice", Grams=150 }, new IngredientDto{ Item="Broccoli", Grams=100 } } },
                        new MealDto { Name = "Snack 2", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Almonds", Grams=25 } } },
                        new MealDto { Name = "Dinner", Kcal = 550, Ingredients = new[]{ new IngredientDto{ Item="Salmon", Grams=180 }, new IngredientDto{ Item="Sweet Potato", Grams=200 }, new IngredientDto{ Item="Asparagus", Grams=100 } } }
                    }
                },
                new DayNutritionDto
                {
                    Day = "Tuesday",
                    Meals = new[]
                    {
                        new MealDto { Name = "Breakfast", Kcal = 400, Ingredients = new[]{ new IngredientDto{ Item="Whole Eggs", Grams=150 }, new IngredientDto{ Item="Spinach", Grams=50 }, new IngredientDto{ Item="Toast", Grams=60 } } },
                        new MealDto { Name = "Snack", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Apple", Grams=150 } } },
                        new MealDto { Name = "Lunch", Kcal = 650, Ingredients = new[]{ new IngredientDto{ Item="Turkey", Grams=180 }, new IngredientDto{ Item="Quinoa", Grams=140 }, new IngredientDto{ Item="Mixed Veg", Grams=120 } } },
                        new MealDto { Name = "Snack 2", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Cottage Cheese", Grams=120 } } },
                        new MealDto { Name = "Dinner", Kcal = 600, Ingredients = new[]{ new IngredientDto{ Item="Beef Stir-fry", Grams=180 }, new IngredientDto{ Item="Rice Noodles", Grams=160 }, new IngredientDto{ Item="Peppers", Grams=80 } } }
                    }
                },
                new DayNutritionDto
                {
                    Day = "Wednesday",
                    Meals = new[]
                    {
                        new MealDto { Name = "Breakfast", Kcal = 420, Ingredients = new[]{ new IngredientDto{ Item="Smoothie (berry)", Grams=450 }, new IngredientDto{ Item="Whey", Grams=30 } } },
                        new MealDto { Name = "Snack", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Rice Cakes", Grams=30 }, new IngredientDto{ Item="Peanut Butter", Grams=20 } } },
                        new MealDto { Name = "Lunch", Kcal = 700, Ingredients = new[]{ new IngredientDto{ Item="Tuna", Grams=200 }, new IngredientDto{ Item="Potato", Grams=200 }, new IngredientDto{ Item="Salad", Grams=100 } } },
                        new MealDto { Name = "Snack 2", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Protein Bar", Grams=60 } } },
                        new MealDto { Name = "Dinner", Kcal = 500, Ingredients = new[]{ new IngredientDto{ Item="Pork Tenderloin", Grams=160 }, new IngredientDto{ Item="Quinoa", Grams=120 }, new IngredientDto{ Item="Green Beans", Grams=80 } } }
                    }
                },
                new DayNutritionDto
                {
                    Day = "Thursday",
                    Meals = new[]
                    {
                        new MealDto { Name = "Breakfast", Kcal = 430, Ingredients = new[]{ new IngredientDto{ Item="Greek Yogurt", Grams=200 }, new IngredientDto{ Item="Granola", Grams=60 }, new IngredientDto{ Item="Honey", Grams=15 } } },
                        new MealDto { Name = "Snack", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Pear", Grams=160 } } },
                        new MealDto { Name = "Lunch", Kcal = 650, Ingredients = new[]{ new IngredientDto{ Item="Grilled Chicken Salad", Grams=300 } } },
                        new MealDto { Name = "Snack 2", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Hummus", Grams=80 }, new IngredientDto{ Item="Carrots", Grams=70 } } },
                        new MealDto { Name = "Dinner", Kcal = 550, Ingredients = new[]{ new IngredientDto{ Item="Cod", Grams=180 }, new IngredientDto{ Item="Polenta", Grams=160 }, new IngredientDto{ Item="Spinach", Grams=90 } } }
                    }
                },
                new DayNutritionDto
                {
                    Day = "Friday",
                    Meals = new[]
                    {
                        new MealDto { Name = "Breakfast", Kcal = 450, Ingredients = new[]{ new IngredientDto{ Item="Pancakes (oat)", Grams=140 }, new IngredientDto{ Item="Blueberries", Grams=80 } } },
                        new MealDto { Name = "Snack", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Boiled Egg", Grams=50 } } },
                        new MealDto { Name = "Lunch", Kcal = 700, Ingredients = new[]{ new IngredientDto{ Item="Salmon Bowl", Grams=220 }, new IngredientDto{ Item="Brown Rice", Grams=140 }, new IngredientDto{ Item="Edamame", Grams=100 } } },
                        new MealDto { Name = "Snack 2", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Trail Mix", Grams=35 } } },
                        new MealDto { Name = "Dinner", Kcal = 550, Ingredients = new[]{ new IngredientDto{ Item="Chicken Curry", Grams=200 }, new IngredientDto{ Item="Cauliflower Rice", Grams=180 } } }
                    }
                },
                new DayNutritionDto
                {
                    Day = "Saturday",
                    Meals = new[]
                    {
                        new MealDto { Name = "Breakfast", Kcal = 480, Ingredients = new[]{ new IngredientDto{ Item="Egg White Omelette", Grams=160 }, new IngredientDto{ Item="Avocado", Grams=80 } } },
                        new MealDto { Name = "Snack", Kcal = 200, Ingredients = new[]{ new IngredientDto{ Item="Protein Shake", Grams=350 } } },
                        new MealDto { Name = "Lunch", Kcal = 700, Ingredients = new[]{ new IngredientDto{ Item="Beef Burger (lean)", Grams=180 }, new IngredientDto{ Item="Sweet Potato Fries", Grams=150 } } },
                        new MealDto { Name = "Snack 2", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Cottage Cheese", Grams=120 } } },
                        new MealDto { Name = "Dinner", Kcal = 500, Ingredients = new[]{ new IngredientDto{ Item="Stir Fry Tofu", Grams=200 }, new IngredientDto{ Item="Mixed Veg", Grams=150 } } }
                    }
                },
                new DayNutritionDto
                {
                    Day = "Sunday",
                    Meals = new[]
                    {
                        new MealDto { Name = "Breakfast", Kcal = 420, Ingredients = new[]{ new IngredientDto{ Item="French Toast (wholegrain)", Grams=120 }, new IngredientDto{ Item="Strawberries", Grams=80 } } },
                        new MealDto { Name = "Snack", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Banana", Grams=120 } } },
                        new MealDto { Name = "Lunch", Kcal = 650, Ingredients = new[]{ new IngredientDto{ Item="Roast Chicken", Grams=200 }, new IngredientDto{ Item="Roast Veg", Grams=180 } } },
                        new MealDto { Name = "Snack 2", Kcal = 150, Ingredients = new[]{ new IngredientDto{ Item="Greek Yogurt", Grams=150 } } },
                        new MealDto { Name = "Dinner", Kcal = 500, Ingredients = new[]{ new IngredientDto{ Item="Grilled Fish", Grams=180 }, new IngredientDto{ Item="Quinoa", Grams=120 }, new IngredientDto{ Item="Salad", Grams=90 } } }
                    }
                }
            },

            Sessions = new[]
            {
                new SessionDto
                {
                    Day = "Monday",
                    Focus = "Upper Body Strength",
                    DurationMin = 60,
                    Exercises = new[]
                    {
                        new ExerciseDto{ Name="Barbell Bench Press", Sets=4, Reps="6-8", Intensity="Heavy" },
                        new ExerciseDto{ Name="Incline Dumbbell Press", Sets=3, Reps="8-10", Intensity="Moderate" },
                        new ExerciseDto{ Name="Bent-over Row", Sets=4, Reps="6-8", Intensity="Heavy" },
                        new ExerciseDto{ Name="Face Pulls", Sets=3, Reps="12-15", Intensity="Light" }
                    }
                },
                new SessionDto
                {
                    Day = "Tuesday",
                    Focus = "Lower Body Strength",
                    DurationMin = 60,
                    Exercises = new[]
                    {
                        new ExerciseDto{ Name="Back Squat", Sets=4, Reps="5-8", Intensity="Heavy" },
                        new ExerciseDto{ Name="Romanian Deadlift", Sets=3, Reps="6-8", Intensity="Moderate" },
                        new ExerciseDto{ Name="Lunges", Sets=3, Reps="10-12", Intensity="Moderate" },
                        new ExerciseDto{ Name="Calf Raises", Sets=3, Reps="12-15", Intensity="Light" }
                    }
                },
                new SessionDto
                {
                    Day = "Wednesday",
                    Focus = "Active Recovery / Cardio",
                    DurationMin = 30,
                    Exercises = new[]
                    {
                        new ExerciseDto{ Name="Steady State Bike", Sets=1, Reps="30 min", Intensity="Low" },
                        new ExerciseDto{ Name="Core Circuit", Sets=3, Reps="15-20", Intensity="Moderate" }
                    }
                },
                new SessionDto
                {
                    Day = "Thursday",
                    Focus = "Push / Pull Hypertrophy",
                    DurationMin = 60,
                    Exercises = new[]
                    {
                        new ExerciseDto{ Name="Overhead Press", Sets=3, Reps="8-10", Intensity="Moderate" },
                        new ExerciseDto{ Name="Lat Pulldown", Sets=3, Reps="10-12", Intensity="Moderate" },
                        new ExerciseDto{ Name="Dumbbell Flyes", Sets=3, Reps="12-15", Intensity="Light" },
                        new ExerciseDto{ Name="Hammer Curls", Sets=3, Reps="10-12", Intensity="Moderate" }
                    }
                },
                new SessionDto
                {
                    Day = "Friday",
                    Focus = "Full Body / Conditioning",
                    DurationMin = 50,
                    Exercises = new[]
                    {
                        new ExerciseDto{ Name="Kettlebell Swings", Sets=5, Reps="20", Intensity="High" },
                        new ExerciseDto{ Name="Pull-ups", Sets=4, Reps="6-10", Intensity="Moderate" },
                        new ExerciseDto{ Name="Goblet Squat", Sets=3, Reps="12", Intensity="Moderate" },
                        new ExerciseDto{ Name="Plank", Sets=3, Reps="60s", Intensity="Moderate" }
                    }
                }
            },

            ShoppingList = new[]
            {
                new ShoppingItemDto{ Item = "Oats", Quantity = "1 kg" },
                new ShoppingItemDto{ Item = "Chicken Breast", Quantity = "2 kg" },
                new ShoppingItemDto{ Item = "Salmon/White Fish", Quantity = "1.2 kg" },
                new ShoppingItemDto{ Item = "Brown Rice/Quinoa", Quantity = "1.5 kg" },
                new ShoppingItemDto{ Item = "Mixed Vegetables", Quantity = "2 kg" },
                new ShoppingItemDto{ Item = "Eggs", Quantity = "2 dozen" },
                new ShoppingItemDto{ Item = "Greek Yogurt", Quantity = "1 kg" },
                new ShoppingItemDto{ Item = "Whey Protein", Quantity = "1 tub" },
                new ShoppingItemDto{ Item = "Almonds", Quantity = "300 g" },
                new ShoppingItemDto{ Item = "Sweet Potato", Quantity = "1.5 kg" }
            },

            Assumptions = new[] { "No food allergies specified", "User has gym access 4-5x/week" },
            Warnings = new[] { "Not medical advice. Consult a professional for medical conditions." }
        };

        return Task.FromResult(plan);
    }
}
