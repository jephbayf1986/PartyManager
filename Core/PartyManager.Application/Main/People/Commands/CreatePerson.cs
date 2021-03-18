using PartyManager.Application.Shared.CQRS;
using System;

namespace PartyManager.Application.Main.People.Commands
{
    public class CreatePerson : ICommand<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? FavouriteDrinkId { get; set; }
    }
}