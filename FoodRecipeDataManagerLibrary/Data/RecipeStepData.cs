using FoodRecipeDataManagerLibrary.Models;
using MinimalAPIDataAccessLibrary.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Data;
public class RecipeStepData : IRecipeStepData
{
	private readonly ISqlDataAccess _data;

	public RecipeStepData(ISqlDataAccess data)
	{
		_data = data;
	}



	public Task<IEnumerable<RecipeStepModel>> GetRecipeSteps(int recipeId)
		=> _data.LoadData<RecipeStepModel, dynamic>("dbo.spRecipeStep_Get", new { RecipeId = recipeId });

	public Task InsertRecipeStep(RecipeStepModel recipeStep) =>
	_data.SaveData("dbo.spRecipeStep_Insert", recipeStep);	

	public Task UpdateRecipeSep(RecipeStepModel recipeStep) =>
		_data.SaveData("dbo.spRecipeStep_Update", recipeStep);

	public Task DeleteRecipeStep(int recipeId, int stepNumber) =>
		_data.SaveData("dbo.spRecipeStep_Delete", new { RecipeId = recipeId, Number = stepNumber });
}
