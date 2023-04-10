using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models.BaseModels;
public class RecipeBaseModel
{    public string Title { get; set; }
    public string Description { get; set; }
    public bool Published { get; set; }    
    public string PictureUrl { get; set; }
    public string UserId { get; set; }
}
