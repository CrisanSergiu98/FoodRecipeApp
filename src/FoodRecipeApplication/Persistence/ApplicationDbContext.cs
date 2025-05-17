using FoodRecipeApplication.Entities;
using FoodRecipeApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeApplication.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
}