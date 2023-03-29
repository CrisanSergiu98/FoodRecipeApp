using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models;
public class RecipeModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Published { get; set; }
    public DateTime CreateDate { get; set; }
    public string PictureUrl { get; set; }
    public string UserId { get; set; }    
    public RecipeCategoryModel Category { get; set; }
    public List<RecipeIngredientDBModel> Ingredients { get; set; }
    public List<RecipeStepModel> Steps { get; set; }

}
