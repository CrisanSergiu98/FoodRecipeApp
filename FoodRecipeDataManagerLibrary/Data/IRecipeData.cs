﻿using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IRecipeData
{
    Task DeleteRecipe(int recipeId);
    Task<IEnumerable<RecipeDBModel>> GetAllRecipe();
    Task<RecipeDBModel?> GetRecipe(int id);
    Task InsertRecipe(RecipeDBModel recipe);
    Task UpdateRecipe(RecipeModel recipe);
}