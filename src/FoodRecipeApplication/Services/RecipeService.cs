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
    public async Task<Result<Recipe>> GetRecipeAsync(Guid id)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);

        if (recipe == null)
        {
            return Result<Recipe>.Failure("Recipe not found");
        }

        return Result<Recipe>.Success(recipe);
    }
}