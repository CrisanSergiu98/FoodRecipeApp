using FoodRecipeDataManagerLibrary.Models;

namespace FoodRecipeDataManagerLibrary.Data;
public interface IUnitData
{
    Task DeleteUnit(int id);
    Task<IEnumerable<UnitModel>> GetAllUnit();
    Task<UnitModel?> GetUnit(int id);
    Task InsertUnit(UnitModel unit);
    Task UpdateUnit(UnitModel unit);
}