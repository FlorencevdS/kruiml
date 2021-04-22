using recipe_service.DBContexts;
using System;
using System.Collections.Immutable;

namespace Logic.Recipe
{
    public class RecipeLogic
    {
        private readonly RecipeContext _recipeContext;

        public RecipeLogic(RecipeContext recipeContext)
        {
            _recipeContext = recipeContext;
        }

        public ImmutableList<Repository.Entities.Recipe> GetAllRecipes()
        {
            return _recipeContext.recipe.ToImmutableList();
        }

        public void InsertRecipe(Repository.Entities.Recipe recipe) {
            _recipeContext.recipe.Add(recipe);
            _recipeContext.SaveChanges();
        }
    }
}
