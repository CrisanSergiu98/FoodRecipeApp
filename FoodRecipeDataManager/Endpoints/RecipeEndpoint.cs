using FoodRecipeDataManagerLibrary.Data;
using FoodRecipeDataManagerLibrary.Models;
using System.Runtime.InteropServices;

namespace FoodRecipeDataManager.Endpoints;

public static class RecipeEndpoint
{
    public static void ConfigureRecipeEndpoints(this WebApplication app)
    {
        app.MapGet("/Recipe", GetAllRecipe);
        app.MapGet("/Recipe/{id}", GetRecipe);
        app.MapPost("/Recipe", InsertRecipe);
        app.MapPut("/Recipe", UpdateRecipe);
        app.MapDelete("Recipe", DeleteRecipe);
    }

    private static async Task<IResult> GetAllRecipe(IRecipeData recipeData, 
        IRecipeCategoryData categoryData,
        IRecipeIngredientData recipeIngredientData,
        IRecipeStepData recipeStepData)
    {
        try
        {
            var result = await recipeData.GetAllRecipe();

            List<RecipeModel> returnResult = new List<RecipeModel>();

            foreach (var i in result)
            {
                var recipeId = i.Id;

                var resultedCategory = await categoryData.GetRecipeCategory(i.CategoryId);

                var ingredientsResult = await recipeIngredientData.GetAllRecipeIngredient(recipeId);

                var stepsResult = await recipeStepData.GetAllRecipeStep(recipeId);

                //Create a new return object and 
                RecipeModel recipe = new RecipeModel
                {
                    Id = i.Id,
                    Title = i.Title,
                    Description = i.Description,
                    Published = i.Published,
                    CreateDate = i.CreateDate,
                    PictureUrl = i.PictureUrl,
                    UserId = i.UserId,
                    //Add the category
                    Category = resultedCategory
                };

                recipe.Ingredients = new List<RecipeIngredientDBModel>();
                recipe.Steps = new List<RecipeStepModel>();

                //Add the ingredients
                foreach (var y in ingredientsResult)
                {
                    recipe.Ingredients.Add(y);
                }

                //Add the steps
                foreach (var y in stepsResult)
                {
                    recipe.Steps.Add(y);
                }

                //Add the details from the DB Model
                returnResult.Add(recipe);
            }

            return Results.Ok(returnResult);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetRecipe(int id, IRecipeData recipeData,
        IRecipeCategoryData categoryData,
        IRecipeIngredientData recipeIngredientData,
        IRecipeStepData recipeStepData)
    {
        try
        {
            var result = await recipeData.GetRecipe(id);            

            var resultedCategory = await categoryData.GetRecipeCategory(result.CategoryId);

            var ingredientsResult = await recipeIngredientData.GetAllRecipeIngredient(result.Id);

            var stepsResult = await recipeStepData.GetAllRecipeStep(result.Id);

            //Create a new return object and 
            RecipeModel recipe = new RecipeModel
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Published = result.Published,
                CreateDate = result.CreateDate,
                PictureUrl = result.PictureUrl,
                UserId = result.UserId,
                //Add the category
                Category = resultedCategory
            };

            foreach (var y in ingredientsResult)
            {
                recipe.Ingredients.Add(y);
            }

            foreach (var y in stepsResult)
            {
                recipe.Steps.Add(y);
            }

            return Results.Ok(recipe);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertRecipe(RecipeDBModel model, IRecipeData recipeData, IRecipeCategoryData categoryData)
    {
        try
        {
            var resultedCategory = await categoryData.GetRecipeCategory(model.CategoryId);

            if (resultedCategory != null)
            {
                await recipeData.InsertRecipe(model);

                return Results.Ok();
            }
            else
            {
                return Results.Problem("Category not found");
            }
            
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateRecipe(RecipeDBModel model, IRecipeData data)
    {
        try
        {
            await data.UpdateRecipe(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteRecipe(int id, IRecipeData data)
    {
        try
        {
            await data.DeleteRecipe(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }
}
