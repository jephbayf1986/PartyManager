using PartyManager.DAL.Mappers.Extensions;
using PartyManager.DAL.Mappers.Helpers;
using PartyManager.Domain;
using System;
using System.Data;

namespace PartyManager.DAL.Mappers
{
    internal static class PersonMapper
    {
        public static Func<IDataReader, Person> BasicMapper =>
            reader => new Person()
            {
                Id = reader["Id"].ToInt(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                DateOfBirth = reader["DOB"].ToDateTime()
            };

        public static Func<IDataReader, Person> DetailedMapper =>
            reader => new Person()
            {
                Id = reader["Id"].ToInt(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                DateOfBirth = reader["DOB"].ToDateTime(),
                Email = reader["Email"].ToString(),
                Phone = reader["Phone"].ToString(),
                FavouriteDrinkId = reader["FavouriteDrinkId"].ToNullableInt(),
                FavouriteDrink = NullHelper.NullableDrink(
                        reader["FavouriteDrinkId"].ToNullableInt(),
                        reader["FavouriteDrink"].ToString()
                    )
            };
    }
}