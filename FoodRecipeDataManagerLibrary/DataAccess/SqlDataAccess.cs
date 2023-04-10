using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace MinimalAPIDataAccessLibrary.DBAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;
    private IDbConnection _connection;
    private IDbTransaction _transaction;
    private bool isClosed = false;

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

    public void StartTransaction()
    {
        string connectionString = _config.GetConnectionString("DefaultDevelopment");
        _connection = new SqlConnection(connectionString);
        _connection.Open();

        _transaction = _connection.BeginTransaction();

        isClosed = false;
    }

    public List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
    {
        try
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

            return rows;
        }
        catch
        {
            throw;
        }
    }

    public void SaveDataInTransaction<T>(string storedProcedure, T parameters)
    {
        try
        {
            _connection.Execute(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);
        }
        catch
        {
            throw;
        }
    }

    public void CommitTransaction()
    {
        _transaction?.Commit();
        _connection?.Close();
        isClosed = true;
    }

    public void RollbackTransaction()
    {
        _transaction?.Rollback();
        _connection?.Close();
        isClosed = true;
    }

    public void Dispose()
    {
        if (isClosed == false)
        {
            try
            {
                CommitTransaction();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Commit transaction failed in the dispose method.");
                throw;
            }
        }

        _transaction = null;
        _connection = null;
    }
}
