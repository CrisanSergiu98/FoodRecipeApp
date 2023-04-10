namespace MinimalAPIDataAccessLibrary.DBAccess;

public interface ISqlDataAccess
{
    void CommitTransaction();
    void Dispose();
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultDevelopment");
    List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);
    void RollbackTransaction();
    Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultDevelopment");
    void SaveDataInTransaction<T>(string storedProcedure, T parameters);
    void StartTransaction();
}