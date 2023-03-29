using FoodRecipeDataManagerLibrary.Data;
using FoodRecipeDataManagerLibrary.Models;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FoodRecipeDataManager.Endpoints;

public static class StepEndpoint
{
    public static void ConfigureSteptEndpoints(this WebApplication app)
    {
        app.MapGet("/RecipeStep/{id}", GetAllRecipeStep);
        app.MapGet("/RecipeStep/{RecipeId},{IngredientId}", GetRecipeStep);
        app.MapPost("/RecipeStep", InsertRecipeStep);
        app.MapPut("/RecipeStep", UpdateRecipeStep);
        app.MapDelete("/RecipeStep/{RecipeId},{StepId}", DeleteRecipeStep);
        app.MapDelete("/RecipeStep/{RecipeId}", DeleteAllRecipeStep);
    }

    private static async Task<IResult> GetAllRecipeStep(int recipeId, IRecipeStepData data)
    {
        try
        {
            await data.GetAllRecipeStep(recipeId);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetRecipeStep(int RecipeId, int IngredientId, IRecipeStepData data)
    {
        try
        {
            await data.GetRecipeStep(RecipeId, IngredientId);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertRecipeStep(RecipeIngredientDBModel ingredient, IRecipeIngredientData data)
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

    private static async Task<IResult> UpdateRecipeStep(RecipeIngredientDBModel ingredient, IRecipeIngredientData data)
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

    private static async Task<IResult> DeleteRecipeStep(int recipeId, int ingredientId, IRecipeIngredientData data)
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

    private static async Task<IResult> DeleteAllRecipeStep(int recipeId, IRecipeIngredientData data)
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
