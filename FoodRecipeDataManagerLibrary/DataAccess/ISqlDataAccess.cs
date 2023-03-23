using System.Data.SqlClient;
using System.Data;

namespace MinimalAPIDataAccessLibrary.DBAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultDevelopment");
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultDevelopment");

    void StartTranzaction(string connectionId = "DefaultDevelopment");
    void SaveDataInTranzaction<T>(string storedProcedures, T parameters);
    public List<T> LoadDataInTranzaction<T, U>(string storedProcedures, U parameters);
    public void CommitTranzaction();
    public void RollbackTranzaction();
    public void Dispose();   
}