using Repository.Contexts;
using Repository.Entities;
using System.Collections.Immutable;
using System.Linq;

namespace Logic
{
    public class RatingLogic
    {
        private readonly RatingContext _ratingContext;

        public RatingLogic(RatingContext ratingContext)
        {
            _ratingContext = ratingContext;
        }

        public ImmutableList<RecipeRatingInformation> GetAllRatings()
        {
            return _ratingContext.Ratings
                .GroupBy(r => r.RecipeId)
                .Select(result =>
                new RecipeRatingInformation { AverageRatingValue = result.Average(v => v.Value), NumberOfRatings = result.Count(), RecipeId = result.Key }).ToImmutableList();
        }

        public RecipeRatingInformation GetAverageRatingByRecipeId(int recipeId)
        {
            RecipeRatingInformation result = new RecipeRatingInformation
            {
                RecipeId = recipeId,
                AverageRatingValue = null,
                NumberOfRatings = 0
            };

            if (_ratingContext.Ratings.Where(r => r.RecipeId == recipeId).Any())
            {
                double averageRating = _ratingContext.Ratings.Where(r => r.RecipeId == recipeId).Average(r => r.Value);
                int totalRatings = _ratingContext.Ratings.Where(r => r.RecipeId == recipeId).Count();
                result.AverageRatingValue = averageRating;
                result.NumberOfRatings = totalRatings;
            }

            return result;
        }

        public void InsertRating(Rating rating)
        {
            _ratingContext.Ratings.Add(rating);
            _ratingContext.SaveChanges();
        }
    }
}
