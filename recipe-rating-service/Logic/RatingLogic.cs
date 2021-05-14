using Repository.Contexts;
using Repository.Entities;
using System;
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

        public ImmutableList<Rating> GetAllRatings()
        {
            return _ratingContext.Ratings.ToImmutableList();
        }

        public object GetAverageRatingByRecipeId(int recipeId)
        {
            return _ratingContext.Ratings.Where(r => r.RecipeId == recipeId).Average(r => r.Value);
        }

        public void InsertRating(Rating rating)
        {
            _ratingContext.Ratings.Add(rating);
            _ratingContext.SaveChanges();
        }
    }
}
