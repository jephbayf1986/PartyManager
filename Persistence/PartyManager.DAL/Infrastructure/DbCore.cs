using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PartyManager.DAL.Infrastructure
{
    public class DbCore : IDbCore
    {
        private const string DataProvider = "System.Data.SqlClient";

        private readonly string ConnectionString;

        private readonly DbProviderFactory _dbProvider;

        public DbCore()
        {
            _dbProvider = DbProviderFactories.GetFactory(DataProvider);

            ConnectionString = "";
        }

        public async Task<IEnumerable<T>> ReadList<T>(string procedureName, Dictionary<string, object> parameters, Func<IDataReader, T> mapper, int? commandTimeout = null)
        {
            using (var connection = GetConnection())
            using (var command = StoredProcedure(connection, procedureName, parameters, commandTimeout))
            {
                connection.Open();

                var result = new List<T>();

                var reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    result.Add(mapper(reader));
                }

                return result;
            }
        }

        public async Task<T> ReadSingle<T>(string procedureName, Dictionary<string, object> parameters, Func<IDataReader, T> mapper, int? commandTimeout = null)
        {
            using (var connection = GetConnection())
            using (var command = StoredProcedure(connection, procedureName, parameters, commandTimeout))
            {
                connection.Open();

                T result = default(T);

                var reader = await command.ExecuteReaderAsync();

                if (reader.Read())
                {
                    result = mapper(reader);
                }

                return result;
            }
        }

        public async Task<object> ExecuteReturnIdentity(string procedureName, Dictionary<string, object> parameters, int? commandTimeout = null)
        {
            using (var connection = GetConnection())
            using (var command = StoredProcedure(connection, procedureName, parameters, commandTimeout))
            {
                connection.Open();

                return await command.ExecuteScalarAsync();
            }
        }

        public async Task Execute(string procedureName, Dictionary<string, object> parameters, int? commandTimeout = null)
        {
            using (var connection = GetConnection())
            using (var command = StoredProcedure(connection, procedureName, parameters, commandTimeout))
            {
                connection.Open();

                await command.ExecuteNonQueryAsync();
            }
        }

        private DbConnection GetConnection()
        {
            var connection = _dbProvider.CreateConnection();

            connection.ConnectionString = ConnectionString;

            return connection;
        }

        private DbCommand StoredProcedure(DbConnection connection, string procedureName, Dictionary<string, object> parameters, int? commandTimeout = null)
        {
            var command = _dbProvider.CreateCommand();

            command.Connection = connection;

            if (commandTimeout != null)
            {
                command.CommandTimeout = commandTimeout.Value;
            }

            command.CommandText = procedureName;

            AddParameters(command, parameters);

            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        private static void AddParameters(DbCommand command, Dictionary<string, object> parameters)
        {
            var hasParameters = parameters?.Any() ?? false;

            if (hasParameters)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(param.Key);
                    command.Parameters.Add(param.Value);
                }
            }
        }
    }
}
