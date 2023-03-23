using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IIngredientData
{
    Task DeleteIngredient(int id);
    Task<IEnumerable<IngredientModel>> GetAllIngredient();
    Task<IngredientModel?> GetIngredient(int id);
    Task InsertIngredient(IngredientModel ingredient);
    Task UpdateIngredient(IngredientModel ingredient);
}