using FoodRecipeDataManagerLibrary.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models;
public class RecipeModel:RecipeBaseModel
{
    public int Id { get; set; }        
    public RecipeCategoryModel Category { get; set; }
    public List<RecipeIngredientDBModel> Ingredients { get; set; }
    public List<RecipeStepModel> Steps { get; set; }

}
