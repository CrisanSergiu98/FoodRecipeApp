using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models.BaseModels;
public class IngredientBaseModel
{    
    public string Name { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public string MesurementType { get; set; }
}
