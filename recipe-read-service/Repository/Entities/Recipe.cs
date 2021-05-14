using System.Collections.Generic;

namespace Repository.Entities
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int PrepTime { get; set; }
        public int Serves { get; set; }
        public int Kcal { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public ICollection<Direction> Directions { get; set; }
    }
}
