using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Models;
public class UnitModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string MesurementType { get; set; }
    public int MetricUnitValue { get; set; }
    public int MetricUnitId { get; set; }
}
