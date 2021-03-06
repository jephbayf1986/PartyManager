using System;

namespace PartyManager.Application.Shared.DataAccess.Requests
{
    public class InsertPersonRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? FavouriteDrinkId { get; set; }
    }
}