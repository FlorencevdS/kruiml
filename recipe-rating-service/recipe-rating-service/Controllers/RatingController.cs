using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Entities;
using System.Transactions;

namespace recipe_rating_service.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {

        private readonly ILogger<RatingController> _logger;
        private readonly RatingLogic _ratingLogic;

        public RatingController(ILogger<RatingController> logger, RatingLogic ratingLogic)
        {
            _logger = logger;
            _ratingLogic = ratingLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Ratings are requested.");

            var ratings = _ratingLogic.GetAllRatings();
            return new OkObjectResult(ratings);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"Rating with recipeId: {id} is requested");

            var recipeRatingInformation = _ratingLogic.GetAverageRatingByRecipeId(id);
            return new OkObjectResult(recipeRatingInformation);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Rating rating)
        {
            _logger.LogInformation($"Rating: {rating} is posted");

            using var scope = new TransactionScope();
            _ratingLogic.InsertRating(rating);
            scope.Complete();
            return CreatedAtAction(nameof(Get), new { id = rating.RatingId }, rating);
        }
    }
}
