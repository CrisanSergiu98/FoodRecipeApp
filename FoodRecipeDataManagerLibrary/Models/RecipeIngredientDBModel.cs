using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models;
public class RecipeIngredientDBModel
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public float Quantity { get; set; }    
    public int UnitId { get; set; }
}
