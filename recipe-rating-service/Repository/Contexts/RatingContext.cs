using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace Repository.Contexts
{
    public class RatingContext : DbContext
    {
        public RatingContext(DbContextOptions<RatingContext> options) : base(options)
        {
        }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Recipe> Recipes { get;set;}

        public ImmutableList<RecipeRatingInformation> GetAllRatings()
        {
            return Ratings
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

            if (Ratings.Where(r => r.RecipeId == recipeId).Any())
            {
                double averageRating = Ratings.Where(r => r.RecipeId == recipeId).Average(r => r.Value);
                int totalRatings = Ratings.Where(r => r.RecipeId == recipeId).Count();
                result.AverageRatingValue = averageRating;
                result.NumberOfRatings = totalRatings;
            }

            return result;
        }

        public Rating GetRatingByRecipeIdAndUserId(int recipeId, string userId)
        {
            return Ratings.Where(r => r.RecipeId == recipeId && r.UserId == userId).FirstOrDefault();
        }

        public void InsertRating(Rating rating)
        {
            Ratings.Add(rating);
            SaveChanges();
        }

        public void InsertNewRecipeId(Recipe recipe)
        {
            Recipes.Add(recipe);
            SaveChanges();
        }
    }
}
