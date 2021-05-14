
namespace Repository.Entities
{
    public class RecipeRatingInformation
    {
        public int RecipeId { get; set; }
        public double AverageRatingValue { get; set; }
        public int NumberOfRatings { get; set; }
    }
}
