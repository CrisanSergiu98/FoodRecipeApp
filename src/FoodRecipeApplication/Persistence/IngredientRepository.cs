using FoodRecipeApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeApplication.Persistence;

public class IngredientRepository
{
    private readonly ApplicationDbContext _dbContext;

    public IngredientRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Ingredient>> GetAllAsync()
    {
        return await _dbContext.Ingredients.ToListAsync();
    }

    public async Task<Ingredient?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Ingredients.FindAsync(id);
    }

    public async Task<bool> Add(Ingredient item)
    {
        _dbContext.Ingredients.Add(item);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Update(Ingredient item)
    {
        _dbContext.Ingredients.Update(item);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        var ingredient = await _dbContext.Ingredients.FindAsync(id);
        if (ingredient == null)
        {
            return false;
        }
        _dbContext.Ingredients.Remove(ingredient);
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }
}