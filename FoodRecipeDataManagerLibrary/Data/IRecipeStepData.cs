using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IRecipeStepData
{
    Task DeleteRecipeStep(int recipeId, int stepNumber);
    Task<IEnumerable<RecipeStepModel>> GetAllRecipeStep(int recipeId);
    Task<RecipeStepModel?> GetRecipeStep(int recipeId, int stepNumber);
    Task InsertRecipeStep(RecipeStepModel recipeStep);
    Task UpdateRecipeStep(RecipeStepModel recipeStep);
    Task DeleteAllRecipeStep(int recipeId);
}