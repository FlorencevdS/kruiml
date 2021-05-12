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
        public void InsertRecipe(Recipe recipe)
        {
            _recipeContext.Recipes.Add(recipe);
            _recipeContext.SaveChanges();
        }
    }
}
