using FoodRecipeDataManagerLibrary.Data;
using FoodRecipeDataManagerLibrary.Models;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FoodRecipeDataManager.Endpoints;

public static class RecipeIngredientEndpoint
{
    public static void ConfigureRecipeIngredientEndpoints(this WebApplication app)
    {
        app.MapGet("/RecipeIngredient/{RecipeId}", GetAllRecipeIngredient);
        app.MapGet("/RecipeIngredient/{RecipeId},{IngredientId}", GetRecipeIngredient);
        app.MapPost("/RecipeIngredient", InsertRecipeIngredient);
        app.MapPut("/RecipeIngredient", UpdateRecipeIngredient);
        app.MapDelete("/RecipeIngredient/{RecipeId},{IngredientId}", DeleteRecipeIngredient);
        app.MapDelete("/RecipeIngredient/{RecipeId}", DeleteAllRecipeIngredient);
    }

    private static async Task<IResult> GetAllRecipeIngredient( int RecipeId , IRecipeIngredientData data)
    {
        try
        {
            var result = await data.GetAllRecipeIngredient(RecipeId);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetRecipeIngredient(int RecipeId, int IngredientId, IRecipeIngredientData data)
    {
        try
        {
            await data.GetRecipeIngredient(RecipeId, IngredientId);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertRecipeIngredient(RecipeIngredientDBModel ingredient, IRecipeIngredientData data)
    {
        try
        {
            await data.InsertRecipeIngredient(ingredient);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateRecipeIngredient(RecipeIngredientDBModel ingredient, IRecipeIngredientData data)
    {
        try
        {
            await data.UpdateRecipeIngredient(ingredient);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteRecipeIngredient(int recipeId, int ingredientId, IRecipeIngredientData data)
    {
        try
        {
            await data.DeleteRecipeIngredient(recipeId, ingredientId);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteAllRecipeIngredient(int recipeId, IRecipeIngredientData data)
    {
        try
        {
            await data.DeleteAllRecipeIngredient(recipeId);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }
}
