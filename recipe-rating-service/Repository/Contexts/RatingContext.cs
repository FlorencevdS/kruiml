using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository.Contexts
{
    public class RatingContext : DbContext
    {
        public RatingContext(DbContextOptions<RatingContext> options) : base(options)
        {
        }
        public DbSet<Rating> Ratings { get; set; }
    }
}
