namespace Repository.Entities
{
    public class Rating
    {
        public int? RatingId { get; set; }
        public int RecipeId { get; set; }
        public string UserId { get; set; }
        public int Value { get; set; }
    }
}
