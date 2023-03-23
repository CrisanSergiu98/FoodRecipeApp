using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IRecipeStepData
{
    Task DeleteRecipeStep(int recipeId, int stepNumber);
    Task<IEnumerable<RecipeStepModel>> GetRecipeSteps(int recipeId);
    Task InsertRecipeStep(RecipeStepModel recipeStep);
    Task UpdateRecipeSep(RecipeStepModel recipeStep);
}