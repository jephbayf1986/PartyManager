using PartyManager.DAL.Mappers.Extensions;
using PartyManager.Domain;
using System;
using System.Data;

namespace PartyManager.DAL.Mappers
{
    internal static class DrinkMapper
    {
        public static Func<IDataReader, Drink> Mapper =>
            reader => new Drink()
            {
                Id = reader["Id"].ToInt(),
                Name = reader["Name"].ToString()
            };
    }
}