using FoodRecipeDataManagerLibrary.Data;
using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManager.Endpoints;

public static class RecipeCategoryEndpoint
{
    public static void ConfigureRecipeCategoryEndpoints(this WebApplication app)
    {
        app.MapGet("/RecipeCategory", GetAllRecipeCategory);
        app.MapGet("/RecipeCategory/{id}", GetRecipeCategory);
        app.MapPost("/RecipeCategory", InsertRecipeCategory);
        app.MapPut("/RecipeCategory", UpdateRecipeCategory);
        app.MapDelete("RecipeCategory", DeleteRecipeCategory);
    }
    private static async Task<IResult> GetAllRecipeCategory(IRecipeCategoryData data)
    {
        try
        {
            return Results.Ok(await data.GetAllRecipeCategory());
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetRecipeCategory(int id, IRecipeCategoryData data)
    {
        try
        {
            var results = await data.GetRecipeCategory(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertRecipeCategory(RecipeCategoryModel model, IRecipeCategoryData data)
    {
        try
        {
            await data.InsertRecipeCategory(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateRecipeCategory(RecipeCategoryModel model, IRecipeCategoryData data)
    {
        try
        {
            await data.UpdateRecipeCategory(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteRecipeCategory(int id, IRecipeCategoryData data)
    {
        try
        {
            await data.DeleteRecipeCategory(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }
}
