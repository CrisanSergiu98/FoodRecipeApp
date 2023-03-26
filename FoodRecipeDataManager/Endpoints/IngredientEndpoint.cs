using FoodRecipeDataManagerLibrary.Data;
using FoodRecipeDataManagerLibrary.Models;
using System.Linq;
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

            List<IngredientModel> returnResult= new List<IngredientModel>();

            foreach (var i in result)
            {
                var resultedCategory = await categoryData.GetIngredientCategory(i.CategoryId);

                IngredientModel ingredient= new IngredientModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    PictureUrl = i.PictureUrl,
                    MesurementType = i.MesurementType,
                    Category = resultedCategory
                };

                returnResult.Add(ingredient);        
            }

            return Results.Ok(returnResult);
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

            var resultedCategory = await categoryData.GetIngredientCategory(result.CategoryId);

            IngredientModel returnResult = new IngredientModel
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                PictureUrl = result.PictureUrl,
                MesurementType = result.MesurementType,
                Category = resultedCategory
            };            

            return Results.Ok(returnResult);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertIngredient(IngredientDBModel model, IIngredientData ingredientData, IIngredientCategoryData categoryData)
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

    private static async Task<IResult> UpdateIngredient(IngredientDBModel model, IIngredientData data)
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
