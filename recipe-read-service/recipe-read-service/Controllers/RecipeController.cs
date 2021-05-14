using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace recipe_read_service.Controllers
{
    [ApiController]
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
        public IActionResult Get()
        {
            _logger.LogInformation("Recipes are requested.");

            var recipes = _recipeLogic.GetAllRecipes();
            return new OkObjectResult(recipes);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"Recipe with id: {id} is requested");

            var recipe = _recipeLogic.GetRecipeByID(id);
            return new OkObjectResult(recipe);
        }
    }
}
