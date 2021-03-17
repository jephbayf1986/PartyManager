using PartyManager.DAL.Mappers.Extensions;
using PartyManager.DAL.Mappers.Helpers;
using PartyManager.Domain;
using System;
using System.Data;

namespace PartyManager.DAL.Mappers
{
    internal static class PartyGuestMapper
    {
        public static Func<IDataReader, PartyGuest> Mapper =>
            reader => new PartyGuest()
            {
                Id = reader["Id"].ToInt(),
                PartyId = reader["PartyId"].ToInt(),
                Party = new Party
                {
                    Id = reader["PartyId"].ToInt(),
                    Name = reader["PartyName"].ToString(),
                    Location = reader["PartyLocation"].ToString(),
                    StartTime = reader["StartTime"].ToDateTime()
                },
                PersonId = reader["PersonId"].ToInt(),
                Person = new Person
                {
                    Id = reader["PersonId"].ToInt(),
                    FirstName = reader["GuestFirstName"].ToString(),
                    LastName = reader["GuestLastName"].ToString(),
                    DateOfBirth = reader["GuestDOB"].ToDateTime(),
                    Email = reader["GuestEmail"].ToString(),
                    Phone = reader["GuestPhone"].ToString(),
                    FavouriteDrinkId = reader["GuestFavouriteDrinkId"].ToNullableInt()
                },
                ChosenDrinkId = reader["ChosenDrinkId"].ToNullableInt(),
                ChosenDrink = NullHelper.NullableDrink(
                        reader["ChosenDrinkId"].ToNullableInt(),
                        reader["ChosenDrink"].ToString()
                    ),
                IsVIP = reader["IsVIP"].ToBool()
            };
    }
}