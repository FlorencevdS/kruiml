using Microsoft.EntityFrameworkCore;
using Repository.Contexts;
using Repository.Entities;
using System.Linq;
using System.Threading.Tasks;

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

            EmitNewRecipeDirect emitNewRecipeDirect = new EmitNewRecipeDirect();
            emitNewRecipeDirect.EmitNewRecipe(recipe);
        }

        public Recipe GetRecipeByID(int id)
        {
            return _recipeContext.Recipes
                .Single(r => r.RecipeId == id);
        }
        
        public void Remove(Recipe recipe)
        {      
            _recipeContext.Remove(recipe);

            _recipeContext.SaveChanges();

            EmitDeleteRecipeDirect emitDeleteRecipeDirect = new EmitDeleteRecipeDirect();
            emitDeleteRecipeDirect.EmitDeleteRecipe(recipe);
        }

    }
}
