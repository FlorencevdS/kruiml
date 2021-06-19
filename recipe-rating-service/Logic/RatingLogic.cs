using Repository.Contexts;
using Repository.Entities;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Logic
{
    public class RatingLogic : IRatingLogic
    {
        private readonly RatingContext _ratingContext;

        public RatingLogic(RatingContext ratingContext)
        {
            _ratingContext = ratingContext;
        }

        public ImmutableList<RecipeRatingInformation> GetAllRatings()
        {
            return _ratingContext.GetAllRatings();
        }

        public RecipeRatingInformation GetAverageRatingByRecipeId(int recipeId)
        {
            return _ratingContext.GetAverageRatingByRecipeId(recipeId);
        }

        public void InsertRating(Rating rating)
        {
            _ratingContext.InsertRating(rating);
        }

        public void InsertNewRecipeId(Recipe recipe)
        {
            _ratingContext.InsertNewRecipeId(recipe);
        }

        public Rating GetRatingByRecipeIdAndUserId(int recipeId, string userId)
        {
            return _ratingContext.GetRatingByRecipeIdAndUserId(recipeId, userId);
        }

        public void DeleteRecipeId(int id)
        {
            var result = _ratingContext.Recipes.OrderBy(r => r.RecipeId).Where(r => r.RecipeId == id);

            IImmutableList<Recipe> recipes = result.Select(r => new Recipe { RecipeId = r.RecipeId }).ToImmutableList();

            _ratingContext.RemoveRange(recipes);

            _ratingContext.SaveChanges();
        }
    }
}
