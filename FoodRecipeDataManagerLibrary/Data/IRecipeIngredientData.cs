using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IRecipeIngredientData
{
    Task DeleteRecipeIngredient(int recipeId, int ingredientId);
    Task<IEnumerable<RecipeIngredientDBModel>> GetAllRecipeIngredient(int recipeId);
    Task<RecipeIngredientDBModel?> GetRecipeIngredient(int recipeId, int ingredientId);
    Task InsertRecipeIngredient(RecipeIngredientDBModel recipeIngredient);
    Task UpdateRecipeIngredient(RecipeIngredientDBModel recipeIngredient);

    Task DeleteAllRecipeIngredient(int recipeId);
}