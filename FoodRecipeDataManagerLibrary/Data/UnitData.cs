using FoodRecipeDataManagerLibrary.Models;
using MinimalAPIDataAccessLibrary.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipeDataManagerLibrary.Data;
public class UnitData : IUnitData
{
    private readonly ISqlDataAccess _data;

    public UnitData(ISqlDataAccess data)
    {
        _data = data;
    }

    public Task<IEnumerable<UnitModel>> GetAllUnit() =>
    _data.LoadData<UnitModel, dynamic>("dbo.spUnit_GetAll", new { });

    public async Task<UnitModel?> GetUnit(int id) =>
        (await _data.LoadData<UnitModel, dynamic>("dbo.spUnit_Get", new { Id = id })).FirstOrDefault();

    public Task InsertUnit(UnitModel unit) =>
        _data.SaveData("dbo.spUnit_Insert", new
        {
            Name = unit.Name,
            Symbol = unit.Symbol,
            MesurementType = unit.MesurementType,
            MetricUnitValue = unit.MetricUnitValue,
            MetricUnitId = unit.MetricUnitId
        });

    public Task UpdateUnit(UnitModel unit) =>
        _data.SaveData("dbo.spUnit_Update", unit);

    public Task DeleteUnit(int id) =>
        _data.SaveData("dbo.spUnit_Delete", new { Id = id });
}
