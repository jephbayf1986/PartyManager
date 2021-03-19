using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PartyManager.DAL.Infrastructure
{
    public class DbCore : IDbCore
    {
        private readonly string ConnectionString;

        public DbCore(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public async Task<IEnumerable<T>> ReadList<T>(string procedureName, Dictionary<string, object> parameters, Func<IDataReader, T> mapper, int? commandTimeout = null)
        {
            using (var connection = GetConnection())
            using (var command = StoredProcedure(connection, procedureName, parameters, commandTimeout))
            {
                connection.Open();

                var result = new List<T>();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        result.Add(mapper(reader));
                    }

                    return result;
                }
            }
        }

        public async Task<T> ReadSingle<T>(string procedureName, Dictionary<string, object> parameters, Func<IDataReader, T> mapper, int? commandTimeout = null)
        {
            using (var connection = GetConnection())
            using (var command = StoredProcedure(connection, procedureName, parameters, commandTimeout))
            {
                connection.Open();

                T result = default(T);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        result = mapper(reader);
                    }

                    return result;
                }
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

        private SqlConnection GetConnection()
        {
            var connection = new SqlConnection(ConnectionString);

            connection.ConnectionString = ConnectionString;

            return connection;
        }

        private SqlCommand StoredProcedure(SqlConnection connection, string procedureName, Dictionary<string, object> parameters, int? commandTimeout = null)
        {
            var command = new SqlCommand(procedureName, connection);

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

        private static void AddParameters(SqlCommand command, Dictionary<string, object> parameters)
        {
            var hasParameters = parameters?.Any() ?? false;

            if (hasParameters)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }
        }
    }
}
