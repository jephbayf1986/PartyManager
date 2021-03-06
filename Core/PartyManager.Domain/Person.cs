using System;

namespace PartyManager.Domain
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? FavouriteDrinkId { get; set; }

        public Drink FavouriteDrink { get; set; }
    }
}