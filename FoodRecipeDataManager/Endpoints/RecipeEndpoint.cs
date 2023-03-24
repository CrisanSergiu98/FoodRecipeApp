using FoodRecipeDataManagerLibrary.Data;
using FoodRecipeDataManagerLibrary.Models;

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

            foreach (var i in result)
            {
                var recipeId = i.Id;

                var resultedCategory = await categoryData.GetRecipeCategory(i.CategoryId);

                var ingredientsResult = await recipeIngredientData.GetAllRecipeIngredient(recipeId);

                var stepsResult = await recipeStepData.GetRecipeSteps(recipeId);

                i.Category = resultedCategory;

                foreach (var y in ingredientsResult)
                {
                    i.Ingredients.Add(y);
                }

                foreach (var y in stepsResult)
                {
                    i.Steps.Add(y);
                }
            }

            return Results.Ok(result);
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

            var recipeId = result.Id;

            var resultedCategory = await categoryData.GetRecipeCategory(result.CategoryId);

            var ingredientsResult = await recipeIngredientData.GetAllRecipeIngredient(recipeId);

            var stepsResult = await recipeStepData.GetRecipeSteps(recipeId);

            result.Category = resultedCategory;

            foreach (var y in ingredientsResult)
            {
                result.Ingredients.Add(y);
            }

            foreach (var y in stepsResult)
            {
                result.Steps.Add(y);
            }

            return Results.Ok(result);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertRecipe(RecipeModel model, IRecipeData recipeData, IRecipeCategoryData categoryData)
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

    private static async Task<IResult> UpdateRecipe(IngredientModel model, IIngredientData data)
    {
        try
        {
            await data.UpdateIngredient(model);
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
