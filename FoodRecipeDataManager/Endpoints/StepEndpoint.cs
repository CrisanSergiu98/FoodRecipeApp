using FoodRecipeDataManagerLibrary.Data;
using FoodRecipeDataManagerLibrary.Models;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FoodRecipeDataManager.Endpoints;

public static class StepEndpoint
{
    public static void ConfigureSteptEndpoints(this WebApplication app)
    {
        app.MapGet("/RecipeStep/{recipeId}", GetAllRecipeStep);
        app.MapGet("/RecipeStep/{recipeId},{stepId}", GetRecipeStep);
        app.MapPost("/RecipeStep", InsertRecipeStep);
        app.MapPut("/RecipeStep", UpdateRecipeStep);
        app.MapDelete("/RecipeStep/{recipeId},{stepId}", DeleteRecipeStep);
        app.MapDelete("/RecipeStep/{recipeId}", DeleteAllRecipeStep);
    }

    private static async Task<IResult> GetAllRecipeStep(int recipeId, IRecipeStepData data)
    {
        try
        {
            var result = await data.GetAllRecipeStep(recipeId);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetRecipeStep(int recipeId, int stepId, IRecipeStepData data)
    {
        try
        {
            var result = await data.GetRecipeStep(recipeId, stepId);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertRecipeStep(RecipeStepModel step, IRecipeStepData data)
    {
        try
        {
            await data.InsertRecipeStep(step);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateRecipeStep(RecipeStepModel step, IRecipeStepData data)
    {
        try
        {
            await data.UpdateRecipeStep(step);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteRecipeStep(int recipeId, int stepId, IRecipeStepData data)
    {
        try
        {
            await data.DeleteRecipeStep(recipeId, stepId);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteAllRecipeStep(int recipeId, IRecipeStepData data)
    {
        try
        {
            await data.DeleteAllRecipeStep(recipeId);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }
}
