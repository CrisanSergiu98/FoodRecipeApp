﻿using FoodRecipeDataManagerLibrary.Models;
using MinimalAPIDataAccessLibrary.DBAccess;
using System.Collections.Generic;

namespace FoodRecipeDataManagerLibrary.Data;
public class IngredientData : IIngredientData
{
    private readonly ISqlDataAccess _data;

    public IngredientData(ISqlDataAccess data)
    {
        _data = data;
    }

    public Task<IEnumerable<IngredientDBModel>> GetAllIngredient() => 
        _data.LoadData<IngredientDBModel, dynamic>("dbo.spIngredient_GetAll", new { });

    public async Task<IngredientDBModel?> GetIngredient(int id) =>
        (await _data.LoadData<IngredientDBModel, dynamic>("dbo.spIngredient_Get", new { Id = id })).FirstOrDefault();

    public Task InsertIngredient(IngredientDBModel ingredient) =>
        _data.SaveData("dbo.spIngredient_Insert", new
        {
            Name=ingredient.Name,
            Description=ingredient.Description,
            PictureUrl=ingredient.PictureUrl,
            CategoryId=ingredient.CategoryId,
            MesurementType=ingredient.MesurementType
        });

    public Task UpdateIngredient(IngredientDBModel ingredient) =>
        _data.SaveData("dbo.spIngredient_Update", ingredient);

    public Task DeleteIngredient(int id) =>
        _data.SaveData("dbo.spIngredient_Delete", new { Id = id });

    

    


}
