using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IIngredientData
{
    Task DeleteIngredient(int id);
    Task<IEnumerable<IngredientDBModel>> GetAllIngredient();
    Task<IngredientDBModel?> GetIngredient(int id);
    Task InsertIngredient(IngredientDBModel ingredient);
    Task UpdateIngredient(IngredientDBModel ingredient);
}