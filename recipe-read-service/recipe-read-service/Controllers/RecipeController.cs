using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace recipe_read_service.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly RecipeLogic _recipeLogic;

        public RecipeController(ILogger<RecipeController> logger, RecipeLogic recipeLogic)
        {
            _logger = logger;
            _recipeLogic = recipeLogic;
        }

        [HttpGet]
        public IActionResult GetAllRecipes()
        {
            _logger.LogInformation("Recipes are requested.");

            var recipes = _recipeLogic.GetAllRecipes();
            return new OkObjectResult(recipes);
        }

        [HttpGet("{id}", Name = "GetByRecipeId")]
        public IActionResult GetRecipeByRecipeId(int id)
        {
            _logger.LogInformation($"Recipe with id: {id} is requested");

            var recipe = _recipeLogic.GetRecipeByID(id);
            return new OkObjectResult(recipe);
        }

        [HttpGet("user/{id}", Name = "GetByUserId")]
        public IActionResult GetRecipesByUserId(string id)
        {
            _logger.LogInformation($"Recipes with userId: {id} are requested");

            var recipes = _recipeLogic.GetRecipesByUserId(id);
            return new OkObjectResult(recipes);
        }
    }
}
