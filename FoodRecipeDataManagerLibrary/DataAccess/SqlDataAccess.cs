using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace MinimalAPIDataAccessLibrary.DBAccess;
public class SqlDataAccess : ISqlDataAccess, IDisposable
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        this._config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultDevelopment")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultDevelopment")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }

    private IDbConnection _connection;
    private IDbTransaction _tranzaction;
    private bool isColsed = false;

    //Start Tranzaction
    public void StartTranzaction(string connectionId = "DefaultDevelopment")
    { 
        _connection = new SqlConnection(_config.GetConnectionString(connectionId));

        _connection.Open();

        _tranzaction = _connection.BeginTransaction();

        isColsed = false;
    }

    public void SaveDataInTranzaction<T>(string storedProcedures, T parameters)
    {
        _connection.Execute(storedProcedures, parameters, commandType: CommandType.StoredProcedure, transaction: _tranzaction);
    }

    public List<T> LoadDataInTranzaction<T, U>(string storedProcedures, U parameters)
    {
        List<T> rows = _connection.Query<T>(storedProcedures, parameters,
                commandType: CommandType.StoredProcedure, transaction: _tranzaction).ToList();
        return rows;
    }

    public void CommitTranzaction()
    {
        //Apply changes to the db
        _tranzaction?.Commit();
        _connection.Close();

        isColsed = true;
    }

    public void RollbackTranzaction()
    {
        //rollback changes
        _tranzaction?.Rollback();
        _connection.Close();

        isColsed = true;
    }

    public void Dispose()
    {
        if (!isColsed)
        {
            try
            {
                CommitTranzaction();
            }
            catch
            {
                //Log issue
            }
        }

        _tranzaction = null;
        _connection = null;
    }
}
