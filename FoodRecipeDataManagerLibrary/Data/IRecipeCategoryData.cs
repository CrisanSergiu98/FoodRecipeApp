using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IRecipeCategoryData
{
    Task DeleteRecipeCategory(int id);
    Task<IEnumerable<RecipeCategoryModel>> GetAllRecipeCategory();
    Task<RecipeCategoryModel?> GetRecipeCategory(int id);
    Task InsertRecipeCategory(RecipeCategoryModel recipeCategory);
    Task UpdateRecipeCategory(RecipeCategoryModel recipeCategory);
}