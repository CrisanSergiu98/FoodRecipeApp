using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models;
public class IngredientDBModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PictureUrl { get; set; }
    public int CategoryId { get; set; }
    public string MesurementType { get; set; }
}
