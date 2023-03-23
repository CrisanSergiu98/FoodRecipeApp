using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IRecipeData
{
    Task DeleteIngredientCategory(int recipeId);
    Task<IEnumerable<RecipeModel>> GetAllRecipe();
    Task<RecipeModel?> GetRecipe(int id);
    Task InsertRecipe(RecipeModel recipe);
    Task UpdateRecipe(RecipeModel recipe);
}