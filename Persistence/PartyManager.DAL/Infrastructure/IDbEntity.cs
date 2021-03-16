using PartyManager.DAL.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PartyManager.DAL.Infrastructure
{
    internal interface IDbEntity<TDbEntity> where TDbEntity : DatabaseEntity
    {
        Task<IEnumerable<T>> GetList<T>(Dictionary<string, object> parameters, Func<IDataReader, T> mapper, int? commandTimeout = null);

        Task<T> GetSingle<T>(Dictionary<string, object> parameters, Func<IDataReader, T> mapper, int? commandTimeout = null);

        Task<object> Insert(Dictionary<string, object> parameters, int? commandTimeout = null);

        Task Update(Dictionary<string, object> parameters, int? commandTimeout = null);

        Task Delete(Dictionary<string, object> parameters, int? commandTimeout = null);
    }
}