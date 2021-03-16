using PartyManager.DAL.DatabaseEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PartyManager.DAL.Infrastructure
{
    internal class DbEntity<TDbEntity> : IDbEntity<TDbEntity> where TDbEntity : DatabaseEntity, new()
    {
        private TDbEntity _entity;

        private IDbCore _dbCore;

        public DbEntity(IDbCore dbCore)
        {
            _entity = new TDbEntity();
            _dbCore = dbCore;
        }

        public Task<IEnumerable<T>> GetList<T>(Dictionary<string, object> parameters, Func<IDataReader, T> mapper, int? commandTimeout = null)
        {
            return _dbCore.ReadList(_entity.GetListSql, parameters, mapper, commandTimeout);
        }

        public Task<T> GetSingle<T>(Dictionary<string, object> parameters, Func<IDataReader, T> mapper, int? commandTimeout = null)
        {
            return _dbCore.ReadSingle(_entity.GetSingleSql, parameters, mapper, commandTimeout);
        }

        public Task<object> Insert(Dictionary<string, object> parameters, int? commandTimeout = null)
        {
            return _dbCore.ExecuteReturnIdentity(_entity.InsertSql, parameters, commandTimeout);
        }

        public Task Update(Dictionary<string, object> parameters, int? commandTimeout = null)
        {
            return _dbCore.Execute(_entity.UpdateSql, parameters, commandTimeout);
        }

        public Task Delete(Dictionary<string, object> parameters = null, int? commandTimeout = null)
        {
            return _dbCore.Execute(_entity.DeleteSql, parameters, commandTimeout);
        }
    }
}