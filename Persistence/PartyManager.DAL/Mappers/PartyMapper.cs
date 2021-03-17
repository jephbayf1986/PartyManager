using PartyManager.DAL.Mappers.Extensions;
using PartyManager.Domain;
using System;
using System.Data;

namespace PartyManager.DAL.Mappers
{
    internal static class PartyMapper
    {
        public static Func<IDataReader, Party> Mapper =>
            reader => new Party()
            {
                Id = reader["Id"].ToInt(),
                Name = reader["Name"].ToString(),
                StartTime = reader["StartTime"].ToDateTime(),
                Location = reader["Location"].ToString()
            };
    }
}