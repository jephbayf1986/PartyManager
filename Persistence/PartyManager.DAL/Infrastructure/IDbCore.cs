using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PartyManager.DAL.Infrastructure
{
    public interface IDbCore
    {
        Task<IEnumerable<T>> ReadList<T>(string sql, Dictionary<string, object> parameters, Func<IDataReader, T> mapper, int? commandTimeout = null);

        Task<T> ReadSingle<T>(string sql, Dictionary<string, object> parameters, Func<IDataReader, T> mapper, int? commandTimeout = null);

        Task<object> ExecuteReturnIdentity(string sql, Dictionary<string, object> parameters, int? commandTimeout = null);

        Task Execute(string sql, Dictionary<string, object> parameters, int? commandTimeout = null);
    }
}