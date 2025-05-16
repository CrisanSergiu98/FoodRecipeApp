using FoodRecipeApplication.Entities;
using FoodRecipeApplication.Persistence;
using FoodRecipeApplication.Shared;

namespace FoodRecipeApplication.Services;

public class RecipeService
{
    private readonly RecipeRepository _recipeRepository;

    public RecipeService(RecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    public async Task<Result<IEnumerable<Recipe>>> GetAllRecipesAsync()
    {
        var recipes = await _recipeRepository.GetAllAsync();
        return recipes.Any()
            ? Result<IEnumerable<Recipe>>.Success(recipes)
            : Result<IEnumerable<Recipe>>.Failure("No recipes found.");
    }
    public async Task<Result<Recipe>> GetRecipeAsync(Guid id)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);
        return recipe == null
            ? Result<Recipe>.Success(recipe)
            : Result<Recipe>.Failure("Recipe with specified id not found.");        
    }
    public async Task<Result<bool>> CreateRecipe(Recipe recipe)
    {
        var result = await _recipeRepository.AddAsync(recipe);
        return result
            ? Result<bool>.Success(true)
            : Result<bool>.Failure("Failed to create recipe.");
    }
    public async Task<Result<bool>> UpdateRecipe(Recipe recipe)
    {
        var result = await _recipeRepository.UpdateAsync(recipe);
        return result
            ? Result<bool>.Success(true)
            : Result<bool>.Failure("Failed to update recipe.");
    }
    public async Task<Result<bool>> DeleteRecipe(Guid id)
    {
        var result = await _recipeRepository.DeleteAsync(id);
        return result
            ? Result<bool>.Success(true)
            : Result<bool>.Failure("Failed to delete recipe.");
    }
}