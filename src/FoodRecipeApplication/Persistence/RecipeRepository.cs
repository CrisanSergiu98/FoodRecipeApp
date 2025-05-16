using FoodRecipeApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeApplication.Persistence;

public class RecipeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public RecipeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return await _dbContext.Recipes.ToListAsync();
    }

    public async Task<Recipe?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Recipes.FindAsync(id);
    }

    public async Task AddAsync(Recipe item)
    {
        _dbContext.Recipes.Add(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Recipe item)
    {
        _dbContext.Recipes.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var recipe = await _dbContext.Recipes.FindAsync(id);

        if (recipe != null)
        {
            _dbContext.Recipes.Remove(recipe);
            await _dbContext.SaveChangesAsync();
        }
    }
}