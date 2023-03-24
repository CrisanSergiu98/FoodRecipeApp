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

    public Task<IEnumerable<RecipeModel>> GetAllRecipe() =>
    _data.LoadData<RecipeModel, dynamic>("dbo.spRecipe_GetAll", new { });

    public async Task<RecipeModel?> GetRecipe(int id) =>
        (await _data.LoadData<RecipeModel, dynamic>("dbo.spRecipe_Get", new { Id = id })).FirstOrDefault();

    public Task InsertRecipe(RecipeModel recipe) =>
        _data.SaveData("dbo.spRecipe_Insert",
            new
            {
                Title = recipe.Title,
                Description = recipe.Description,
                PictureUrl = recipe.PictureUrl,
                CategoryId = recipe.CategoryId,
                UserId = recipe.UserId,
                Published = recipe.Published
            });

    public Task InsertRecipeDetails(RecipeModel recipe)
    {
        using (SqlDataAccess insertData = new SqlDataAccess(_config))
        {
            try
            {
                //Save ingredients
                foreach (var i in recipe.Ingredients)
                {
                    insertData.SaveDataInTranzaction("dbo.spRecipeIngredient_Insert", i);
                }
                //Save Steps
                foreach (var i in recipe.Steps)
                {
                    insertData.SaveDataInTranzaction("dbo.spRecipeStep_Insert", i);
                }
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                insertData.RollbackTranzaction();
                throw;
            }
        }
    }

    public Task UpdateRecipe(RecipeModel recipe)
    {
        using (SqlDataAccess insertData = new SqlDataAccess(_config))
        {
            {
                try
                {
                    insertData.StartTranzaction();
                    //Update the recipe details
                    insertData.SaveDataInTranzaction("dbo.spRecipe_Update", new
                    {
                        Title = recipe.Title,
                        Description = recipe.Description,
                        Published = recipe.Published,
                        PictureUrl = recipe.PictureUrl,
                        Category = recipe.CategoryId
                    });
                    //Update ingredients
                    foreach (var i in recipe.Ingredients)
                    {
                        insertData.SaveDataInTranzaction("dbo.spRecipeIngredient_Update", i);
                    }
                    //Update Steps
                    foreach (var i in recipe.Steps)
                    {
                        insertData.SaveDataInTranzaction("dbo.spRecipeStep_Update", i);
                    }
                    return Task.CompletedTask;

                }
                catch (Exception ex)
                {
                    insertData.RollbackTranzaction();
                    throw;
                }
            }
        }
    }

    public async Task DeleteRecipe(int recipeId)
    {
        using (SqlDataAccess insertData = new SqlDataAccess(_config))
        {
            try
            {
                insertData.StartTranzaction();
                //Save the recipe details
                insertData.SaveDataInTranzaction("dbo.spRecipe_Delete", new { Id = recipeId });
                //Save ingredients
                insertData.SaveDataInTranzaction("dbo.spRecipeIngredient_DeleteAll", new { Id = recipeId });
                //Save Steps
                insertData.SaveDataInTranzaction("dbo.spRecipeStep_DeleteAll", new { Id = recipeId });
            }
            catch (Exception ex)
            {
                insertData.RollbackTranzaction();
                throw;
            }
        }
    }

}
