using Logic;
using Microsoft.AspNetCore.Mvc;

namespace ingredient_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientLogic _ingredientLogic;
        public IngredientController (IngredientLogic ingredientLogic)
        {
            _ingredientLogic = ingredientLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ingredients = _ingredientLogic.GetAllIngredients();
            return new OkObjectResult(ingredients);
        }


    }
}
