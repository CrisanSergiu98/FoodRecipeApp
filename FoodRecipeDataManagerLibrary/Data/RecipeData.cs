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

    //public Task InsertRecipe(RecipeDBModel recipe) => 
    //    _data.SaveData("dbo.spRecipe_Insert", new
    //    {
    //        Title=recipe.Title,
    //        Description=recipe.Description,
    //        Published = false,
    //        //CreateDate=recipe.CreateDate,
    //        PictureUrl=recipe.PictureUrl,
    //        UserId=recipe.UserId,
    //        CategoryId=recipe.CategoryId
    //    });

    public Task InsertRecipe(RecipeModel recipe)
    {
        var recipeDB = new RecipeDBModel
        {
            Title=recipe.Title,
            Description=recipe.Description,
            Published=recipe.Published,            
            PictureUrl=recipe.PictureUrl,
            UserId=recipe.UserId,
            CategoryId=recipe.Category.Id
        };
        try
        {
            _data.StartTransaction();

            //1.Check if there is a recipe with this title already 

            var lookupResult = 0;                
            
            lookupResult=_data.LoadDataInTransaction<int, dynamic>("spRecipe_Lookup", new { Title = recipeDB.Title }).FirstOrDefault();

            if (lookupResult > 0)
            {
                return Task.FromException(new Exception("There's a recipe with this title already."));
            }

            //2.Add recipe details

            _data.SaveDataInTransaction<dynamic>("spRecipe_Insert", new
            {
                Title = recipe.Title,
                Description = recipe.Description,
                Published = recipe.Published,
                PictureUrl = recipe.PictureUrl,
                UserId = recipe.UserId,
                CategoryId = recipe.Category.Id
            });

            //3.Get the Id

            var recipeId = 0;

            recipeId = _data.LoadDataInTransaction<int, dynamic>("spRecipe_Lookup", new { Title = recipeDB.Title }).FirstOrDefault();

            //Add recipeIngrediets

            foreach(var i in recipe.Ingredients)
            {
                i.RecipeId = recipeId;

                _data.SaveDataInTransaction<dynamic>("spRecipeIngredient_Insert", i);
            }

            foreach (var i in recipe.Steps)
            {
                i.RecipeId = recipeId;

                _data.SaveDataInTransaction<dynamic>("spRecipeStep_Insert", i);
            }

            //Add steps
            _data.CommitTransaction();
            return Task.CompletedTask;
        }
        catch
        {
            _data.RollbackTransaction();
            throw;
        }
    }

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
