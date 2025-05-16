using FoodRecipeApplication.Persistence;

namespace FoodRecipeApplication.Services;

public class RecipeService
{
    private readonly RecipeRepository _recipeRepository;

    public RecipeService(RecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
}