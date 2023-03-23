using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IRecipeIngredientData
{
    Task DeleteRecipeIngredient(int recipeId, int ingredientId);
    Task<IEnumerable<RecipeIngredientModel>> GetAllRecipeIngredient(int recipeId);
    Task<RecipeIngredientModel?> GetRecipeIngredient(int recipeId, int ingredientId);
    Task InsertRecipeIngredient(RecipeIngredientModel recipeIngredient);
    Task UpdateRecipeIngredient(RecipeIngredientModel recipeIngredient);
}