using FoodRecipeDataManagerLibrary.Data;
using FoodRecipeDataManagerLibrary.Models;
using System.Runtime.CompilerServices;

namespace FoodRecipeDataManager.Endpoints;

public static class UnitEndpoint
{
    public static void ConfigureUnitEndpoints(this WebApplication app)
    {
        app.MapGet("Unit", GetAllUnit);
        app.MapGet("/Unit/{id}", GetUnit);
        app.MapPost("/Unit", InsertUnit);
        app.MapPut("/Unit", UpdateUnit);
        app.MapDelete("Unit", DeleteUnit);
    }

    private static async Task<IResult> GetAllUnit(IUnitData data)
    {
        try
        {
            return Results.Ok(await data.GetAllUnit());
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUnit(int id, IUnitData data)
    {
        try
        {
            var results = await data.GetUnit(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUnit(UnitModel model, IUnitData data)
    {
        try
        {
            await data.InsertUnit(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUnit(UnitModel model, IUnitData data)
    {
        try
        {
            await data.UpdateUnit(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUnit(int id, IUnitData data)
    {
        try
        {
            await data.DeleteUnit(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }
}

