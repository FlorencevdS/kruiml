using Repository.Contexts;
using Repository.Entities;
using System.Collections.Generic;

namespace IntegrationTests.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(RecipeContext db)
        {
            db.Recipes.AddRange(GetSeedingRecipes());
            db.Ingredients.AddRange(GetSeedingIngredients());
            db.Directions.AddRange(GetSeedingDirections());
            db.RecipeIngredients.AddRange(GetSeedingRecipeIngredients());
            db.SaveChanges();
        }
        public static void ReinitializeDbForTests(RecipeContext db)
        {
            db.Recipes.RemoveRange(db.Recipes);
            db.Ingredients.RemoveRange(db.Ingredients);
            db.Directions.RemoveRange(db.Directions);
            db.Ingredients.RemoveRange(db.Ingredients);
            InitializeDbForTests(db);
        }

        public static List<Recipe> GetSeedingRecipes()
        {
            return new List<Recipe>()
            {
                new Recipe(){ Title = "Hummus", Description = "Best hummus ever.", ImageUrl = "HummusImage",
                    Kcal = 300, PrepTime = 10, Serves = 4, RecipeId = 1 },
                new Recipe(){ Title = "Soup", Description = "You must love this soup.", ImageUrl = "SoupImage",
                    Kcal = 600, PrepTime = 40, Serves = 8, RecipeId = 2 },
            };
        }

        public static List<Ingredient> GetSeedingIngredients()
        {
            return new List<Ingredient>()
            {
                new Ingredient(){ Name = "Chickpeas", IngredientId = 1 },
                new Ingredient(){ Name = "Mushrooms", IngredientId = 2 },
            };
        }

        public static List<Direction> GetSeedingDirections()
        {
            return new List<Direction>()
            {
                new Direction(){ Description = "Mix it.", RecipeId = 1, DirectionId = 1 },
                new Direction(){ Description = "Heat it", RecipeId = 2, DirectionId = 2 },
            };
        }

        public static List<RecipeIngredient> GetSeedingRecipeIngredients()
        {
            return new List<RecipeIngredient>()
            {
                new RecipeIngredient(){ RecipeId = 1, IngredientId = 1, Amount = 400, RecipeIngredientId = 1, Unit = "g" },
                new RecipeIngredient(){ RecipeId = 2, IngredientId = 2, Amount = 500, RecipeIngredientId = 2, Unit = "g" },
            };
        }
    }
}
