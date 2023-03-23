using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IIngredientCategoryData
{
    Task DeleteIngredientCategory(int id);
    Task<IEnumerable<IngredientCategoryModel>> GetAllIngredientCategory();
    Task<IngredientCategoryModel?> GetIngredientCategory(int id);
    Task InsertIngredientCategory(IngredientCategoryModel ingredientCategory);
    Task UpdateIngredientCategory(IngredientCategoryModel ingredientCategory);
}