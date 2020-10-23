using CWM.StoreManager.Application.Abstractions.Persistence;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Persistence
{
    public class ApplicationDbConnection : IApplicationDbConnection, IDisposable
    {
        private readonly IDbConnection connection;

        private bool disposedValue = false;

        public ApplicationDbConnection(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString(PersistenceLayerConstants.DatabaseConnectionStringName));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.ExecuteAsync(sql, param, transaction));
        }

        public async Task<int> ExecuteStoredProcedureAsync(string storedProcedureName, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.ExecuteAsync(storedProcedureName, param, transaction));
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    connection.Dispose();
                }
                disposedValue = true;
            }
        }
    }
}
