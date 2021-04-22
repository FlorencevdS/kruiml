namespace Repository.Entities
{
    public class Recipe
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int likes { get; set; }
        public int preptime { get; set; }
        public int serves { get; set; }
        public int kcal { get; set; }
    }
}
