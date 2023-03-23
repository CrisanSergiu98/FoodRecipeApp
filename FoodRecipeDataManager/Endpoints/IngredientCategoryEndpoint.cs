using FoodRecipeDataManagerLibrary.Data;
using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManager.Endpoints;

public static class IngredientCategoryEndpoint
{
    public static void ConfigureIngredientCategoryEndpoints(this WebApplication app)
    {
        app.MapGet("/IngredientCategory", GetAllIngredientCategory);
        app.MapGet("/IngredientCategory/{id}", GetIngredientCategory);
        app.MapPost("/IngredientCategory", InsertIngredientCategory);
        app.MapPut("/IngredientCategory", UpdateIngredientCategory);
        app.MapDelete("IngredientCategory", DeleteIngredientCategory);
    }
    private static async Task<IResult> GetAllIngredientCategory(IIngredientCategoryData data)
    {
        try
        {
            return Results.Ok(await data.GetAllIngredientCategory());
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetIngredientCategory(int id, IIngredientCategoryData data)
    {
        try
        {
            var results = await data.GetIngredientCategory(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertIngredientCategory(IngredientCategoryModel model, IIngredientCategoryData data)
    {
        try
        {
            await data.InsertIngredientCategory(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateIngredientCategory(IngredientCategoryModel model, IIngredientCategoryData data)
    {
        try
        {
            await data.UpdateIngredientCategory(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteIngredientCategory(int id, IIngredientCategoryData data)
    {
        try
        {
            await data.DeleteIngredientCategory(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }
}
