using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models;
public class RecipeIngredientModel
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
    public float Quanity { get; set; }
    public UnitModel Unit { get; set; }
    public int UnitId { get; set; }
}
