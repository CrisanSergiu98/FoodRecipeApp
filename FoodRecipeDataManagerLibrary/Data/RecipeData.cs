using FoodRecipeDataManagerLibrary.Models;
using Microsoft.Extensions.Configuration;
using MinimalAPIDataAccessLibrary.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Data;
public class RecipeData : IRecipeData
{
    private readonly ISqlDataAccess _data;
    private readonly IConfiguration _config;

    public RecipeData(ISqlDataAccess data, IConfiguration config)
    {
        _data = data;
        _config = config;
    }

    public Task<IEnumerable<RecipeDBModel>> GetAllRecipe() =>
    _data.LoadData<RecipeDBModel, dynamic>("dbo.spRecipe_GetAll", new { });

    public async Task<RecipeDBModel?> GetRecipe(int id) =>
        (await _data.LoadData<RecipeDBModel, dynamic>("dbo.spRecipe_Get", new { Id = id })).FirstOrDefault();

    public Task InsertRecipe(RecipeDBModel recipe) => 
        _data.SaveData("dbo.spRecipe_Insert", new
        {
            Title=recipe.Title,
            Description=recipe.Description,
            Published = false,
            //CreateDate=recipe.CreateDate,
            PictureUrl=recipe.PictureUrl,
            UserId=recipe.UserId,
            CategoryId=recipe.CategoryId
        });    

    public Task UpdateRecipe(RecipeDBModel recipe)=>
        _data.SaveData("dbo.spRecipe_Update", new 
        {
            Id=recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            Published = recipe.Published,            
            PictureUrl = recipe.PictureUrl,            
            CategoryId = recipe.CategoryId
        });

    public Task DeleteRecipe(int recipeId) =>
        _data.SaveData("dbo.spRecipe_Delete", new { ID = recipeId });


}
