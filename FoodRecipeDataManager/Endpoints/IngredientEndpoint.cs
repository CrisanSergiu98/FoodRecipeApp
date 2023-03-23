using FoodRecipeDataManagerLibrary.Data;
using FoodRecipeDataManagerLibrary.Models;
using System.Runtime.CompilerServices;

namespace FoodRecipeDataManager.Endpoints;

public static class IngredientEndpoint
{
	public static void ConfigureIngredientEndpoints(this WebApplication app)
	{
        app.MapGet("/Ingredient", GetAllIngredient);
        app.MapGet("/Ingredient/{id}", GetIngredient);
        app.MapPost("/Ingredient", InsertIngredient);
        app.MapPut("/Ingredient", UpdateIngredient);
        app.MapDelete("Ingredient", DeleteIngredient);
    }

    private static async Task<IResult> GetAllIngredient(IIngredientData ingredientData, IIngredientCategoryData categoryData)
    {
        try
        {
            var result = await ingredientData.GetAllIngredient();

            foreach(var i in result)
            {
                var resultedCategory = await categoryData.GetIngredientCategory(i.CategoryId);                
                
                i.Category = resultedCategory;
            }

            return Results.Ok(result);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetIngredient(int id, IIngredientData ingredientData, IIngredientCategoryData categoryData)
    {
        try
        {
            var result = await ingredientData.GetIngredient(id);            
            if (result == null) return Results.NotFound();

            result.Category = await categoryData.GetIngredientCategory(result.CategoryId);

            return Results.Ok(result);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertIngredient(IngredientModel model, IIngredientData ingredientData, IIngredientCategoryData categoryData)
    {    
        try
        {
            await ingredientData.InsertIngredient(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateIngredient(IngredientModel model, IIngredientData data)
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

    private static async Task<IResult> DeleteIngredient(int id, IIngredientData data)
    {
        try
        {
            await data.DeleteIngredient(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }
}
