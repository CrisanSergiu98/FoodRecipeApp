
using FoodRecipeDataManagerLibrary.Models;
using MinimalAPIDataAccessLibrary.DBAccess;

namespace FoodRecipeDataManagerLibrary.Data;
public class IngredientCategoryData : IIngredientCategoryData
{
    private readonly ISqlDataAccess _data;

    public IngredientCategoryData(ISqlDataAccess data)
    {
        _data = data;
    }

    public Task<IEnumerable<IngredientCategoryModel>> GetAllIngredientCategory() =>
        _data.LoadData<IngredientCategoryModel, dynamic>("dbo.spIngredientCategory_GetAll", new { });

    public async Task<IngredientCategoryModel?> GetIngredientCategory(int id) =>
        (await _data.LoadData<IngredientCategoryModel, dynamic>("dbo.spIngredientCategory_Get", new { Id = id })).FirstOrDefault();

    public Task InsertIngredientCategory(IngredientCategoryModel ingredientCategory) =>
        _data.SaveData("dbo.spIngredientCategory_Insert", new { Name = ingredientCategory.Name, Description = ingredientCategory.Description, PictureUrl = ingredientCategory.PictureUrl });

    public Task UpdateIngredientCategory(IngredientCategoryModel ingredientCategory) =>
        _data.SaveData("dbo.spIngredientCategory_Update", ingredientCategory);

    public Task DeleteIngredientCategory(int id) =>
        _data.SaveData("dbo.spIngredientCategory_Delete", new { Id = id });
}
