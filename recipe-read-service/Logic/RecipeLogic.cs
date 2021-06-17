using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Entities;

namespace Logic
{
    public class RecipeLogic
    {
        private readonly RecipeContext _recipeContext;

        public RecipeLogic(RecipeContext recipeContext)
        {
            _recipeContext = recipeContext;
        }
        public ImmutableList<Recipe> GetAllRecipes()
        {
            var recipes = _recipeContext.Recipes
                .Include(r => r.Directions)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(r => r.Ingredient)
                .AsSplitQuery();
            return recipes.ToImmutableList();
        }

        public Recipe GetRecipeByID(int id)
        {
            return _recipeContext.Recipes
                .Include(r => r.Directions)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(r => r.Ingredient)
                .AsSplitQuery()
                .FirstOrDefault(r => r.RecipeId == id);
        }

        public object GetRecipesByUserId(string id)
        {
            return _recipeContext.Recipes
                .Include(r => r.Directions)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(r => r.Ingredient)
                .AsSplitQuery()
                .Where(r => r.UserId == id);
        }
    }
}
