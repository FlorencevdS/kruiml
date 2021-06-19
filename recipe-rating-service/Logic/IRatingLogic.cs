using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace Logic
{
    public interface IRatingLogic
    {
        public ImmutableList<RecipeRatingInformation> GetAllRatings();

        public RecipeRatingInformation GetAverageRatingByRecipeId(int recipeId);

        public void InsertRating(Rating rating);

        public void InsertNewRecipeId(Recipe recipe);
        public void DeleteRecipeId(int id);
    }
}
