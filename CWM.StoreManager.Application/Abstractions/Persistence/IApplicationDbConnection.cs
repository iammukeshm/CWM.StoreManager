using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Abstractions.Persistence
{
    public interface IApplicationDbConnection
    {
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);

        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);

        Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);

        Task<int> ExecuteStoredProcedureAsync(string storedProcedureName, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
    }
}