using FoodRecipeDataManagerLibrary.Models;
using MinimalAPIDataAccessLibrary.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Data;
public class RecipeIngredientData : IRecipeIngredientData
{
    private readonly ISqlDataAccess _data;

    public RecipeIngredientData(ISqlDataAccess data)
    {
        _data = data;
    }

    public Task<IEnumerable<RecipeIngredientModel>> GetAllRecipeIngredient(int recipeId) =>
    _data.LoadData<RecipeIngredientModel, dynamic>("dbo.spRecipeIngredient_GetAll", new { RecipeId = recipeId });

    public async Task<RecipeIngredientModel?> GetRecipeIngredient(int recipeId, int ingredientId) =>
        (await _data.LoadData<RecipeIngredientModel, dynamic>("dbo.spRecipeIngredient_Get", new
        {
            RecipeId = recipeId,
            IngredientId = ingredientId
        })).FirstOrDefault();

    public Task InsertRecipeIngredient(RecipeIngredientModel recipeIngredient) =>
        _data.SaveData("dbo.spRecipeIngredient_Insert", new
        {
            RecipeId = recipeIngredient.RecipeId,
            IngredientId = recipeIngredient.IngredientId,
            Quantity = recipeIngredient.Quanity,
            UnitId = recipeIngredient.UnitId,
        });

    public Task UpdateRecipeIngredient(RecipeIngredientModel recipeIngredient) =>
        _data.SaveData("dbo.spRecipeIngredient_Update", recipeIngredient);

    public Task DeleteRecipeIngredient(int recipeId, int ingredientId) =>
        _data.SaveData("dbo.spRecipeIngredient_Delete", new { RecipeId = recipeId, IngredientId = ingredientId });
}
