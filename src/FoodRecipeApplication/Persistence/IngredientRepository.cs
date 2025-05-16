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

    public async Task Add(Ingredient item)
    {
        _dbContext.Ingredients.Add(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Ingredient item)
    {
        _dbContext.Ingredients.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var ingredient = await _dbContext.Ingredients.FindAsync(id);
        if (ingredient != null)
        {
            _dbContext.Ingredients.Remove(ingredient);
        }
    }
}