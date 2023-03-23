using FoodRecipeDataManagerLibrary.Models;
using MinimalAPIDataAccessLibrary.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Data;
public class RecipeCategoryData : IRecipeCategoryData
{
    private readonly ISqlDataAccess _data;

    public RecipeCategoryData(ISqlDataAccess data)
    {
        _data = data;
    }

    public Task<IEnumerable<RecipeCategoryModel>> GetAllRecipeCategory() =>
    _data.LoadData<RecipeCategoryModel, dynamic>("dbo.spRecipeCategory_GetAll", new { });

    public async Task<RecipeCategoryModel?> GetRecipeCategory(int id) =>
        (await _data.LoadData<RecipeCategoryModel, dynamic>("dbo.spRecipeCategory_Get", new { Id = id })).FirstOrDefault();

    public Task InsertRecipeCategory(RecipeCategoryModel recipeCategory) =>
        _data.SaveData("dbo.spRecipeCategory_Insert", new { Name = recipeCategory.Name, Description = recipeCategory.Description, PictureUrl = recipeCategory.PictureUrl });

    public Task UpdateRecipeCategory(RecipeCategoryModel recipeCategory) =>
        _data.SaveData("dbo.spRecipeCategory_Update", recipeCategory);

    public Task DeleteRecipeCategory(int id) =>
        _data.SaveData("dbo.spRecipeCategory_Delete", new { Id = id });
}
