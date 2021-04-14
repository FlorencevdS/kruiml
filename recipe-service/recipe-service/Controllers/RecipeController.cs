using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Transactions;
using Logic.Recipe;
using Repository.Entities;

namespace recipe_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeLogic _recipeLogic;

        public RecipeController(RecipeLogic recipeLogic)
        {
            _recipeLogic = recipeLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var recipes = _recipeLogic.GetAllRecipes();
            return new OkObjectResult(recipes);
        }

    //    [HttpGet("{id}", Name = "Get")]
    //    public IActionResult Get(int id)
    //    {
    //        var recipe = _recipeLogic.GetRecipeByID(id);
    //        return new OkObjectResult(recipe);
    //    }

        [HttpPost]
        public IActionResult Post([FromBody] Recipe recipe)
        {
            using var scope = new TransactionScope();
            _recipeLogic.InsertRecipe(recipe);
            scope.Complete();
            return CreatedAtAction(nameof(Get), new { id = recipe.id }, recipe);
        }

    //    [HttpPut]
    //    public IActionResult Put([FromBody] Recipe recipe)
    //    {
    //        if (recipe != null)
    //        {
    //            using var scope = new TransactionScope();
    //            _recipeLogic.UpdateRecipe(recipe);
    //            scope.Complete();
    //            return new OkResult();
    //        }
    //        return new NoContentResult();
    //    }

    //    [HttpDelete("{id}")]
    //    public IActionResult Delete(int id)
    //    {
    //        _recipeLogic.DeleteRecipe(id);
    //        return new OkResult();
    //    }
    }
}