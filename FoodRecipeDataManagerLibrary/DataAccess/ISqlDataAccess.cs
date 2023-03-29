using System.Data.SqlClient;
using System.Data;

namespace MinimalAPIDataAccessLibrary.DBAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultDevelopment");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultDevelopment");      
}