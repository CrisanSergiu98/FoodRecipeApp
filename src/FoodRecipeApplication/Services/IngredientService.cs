using FoodRecipeApplication.Entities;
using FoodRecipeApplication.Persistence;
using FoodRecipeApplication.Shared;

namespace FoodRecipeApplication.Services;

public class IngredientService
{
    private readonly IngredientRepository _repository;
    public IngredientService(IngredientRepository repository)
    {
        _repository = repository;
    }
    public async Task<Result<IEnumerable<Ingredient>>> GetAllIngredients()
    {
        var result = await _repository.GetAllAsync();
        return result.Any()
            ? Result<IEnumerable<Ingredient>>.Success(result)
            : Result<IEnumerable<Ingredient>>.Failure("No ingredients found.");
    }
    public async Task<Result<Ingredient>> GetIngredientById(Guid id)
    {
        var result = await _repository.GetByIdAsync(id);
        return result == null
            ? Result<Ingredient>.Success(result)
            : Result<Ingredient>.Failure("Ingredient with specified id cannot be found.");
    }
    public async Task<Result<bool>> CreateIngredient(Ingredient ingredient)
    {
        var result = await _repository.Add(ingredient);
        return result
            ? Result<bool>.Success(result)
            : Result<bool>.Failure("Failed to create ingredient.");
    }
    public async Task<Result<bool>> UpdateIngredient(Ingredient ingredient)
    {
        var result = await _repository.Update(ingredient);
        return result
            ? Result<bool>.Success(result)
            : Result<bool>.Failure("Failed to update ingredient.");
    }
    public async Task<Result<bool>> DeleteIngredient(Guid id)
    {
        var result = await _repository.Delete(id);
        return result
            ? Result<bool>.Success(result)
            : Result<bool>.Failure("Failed to delete ingredient.");
    }
}