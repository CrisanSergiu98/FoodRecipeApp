using FoodRecipeDataManagerLibrary.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models;
public class RecipeDBModel:RecipeBaseModel
{
    public int Id { get; set; }    
    public int CategoryId { get; set; }
    public DateTime CreateDate { get
        {
            return DateTime.Now;
        } 
    }
}
