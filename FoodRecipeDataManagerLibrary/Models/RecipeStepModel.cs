using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models;
public class RecipeStepModel
{
    public int RecipeId { get; set; }
    public int Number { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
}
