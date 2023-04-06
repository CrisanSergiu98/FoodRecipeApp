using FoodRecipeDataManagerLibrary.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models;
public class IngredientModel:IngredientBaseModel
{
    public int Id { get; set; }    
    public IngredientCategoryModel Category { get; set; }    
    
}
