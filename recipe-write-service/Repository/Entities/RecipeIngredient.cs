using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class RecipeIngredient
    {
        public int? RecipeIngredientId { get; set; }
        public int? RecipeId { get; set; }
        public int? IngredientId { get; set; }
        public double? Amount { get; set; }
        public string? Unit { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
