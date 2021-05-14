using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Entities
{
    public class Direction
    {
        public int? DirectionId { get; set; }
        public string Description { get; set; }
        public int? RecipeId { get; set; }
    }
}
