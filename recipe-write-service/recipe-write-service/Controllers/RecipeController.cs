﻿using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Entities;
using System.Transactions;

namespace recipe_write_service.Controllers
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

        [HttpPost]
        public IActionResult Post([FromBody] Recipe recipe)
        {
            _logger.LogInformation($"Recipe: {recipe} is posted");

            using var scope = new TransactionScope();
            _recipeLogic.InsertRecipe(recipe);
            scope.Complete();
            return CreatedAtAction(nameof(Post), new { id = recipe.RecipeId }, recipe);
        }
    }
}
