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

    public async Task<bool> AddAsync(Recipe item)
    {
        _dbContext.Recipes.Add(item);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateAsync(Recipe item)
    {
        _dbContext.Recipes.Update(item);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var recipe = await _dbContext.Recipes.FindAsync(id);
        if (recipe == null)
        {
            return false;
        }
        _dbContext.Recipes.Remove(recipe);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }
}