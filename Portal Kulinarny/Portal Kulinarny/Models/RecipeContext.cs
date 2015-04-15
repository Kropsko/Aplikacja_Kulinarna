using System.Data.Entity;

namespace Portal_Kulinarny.Models
{
    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
    }
}