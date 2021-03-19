using PartyManager.Application.Main.Drinks.Queries.Models;
using PartyManager.Application.Main.Parties.Queries.Models;
using System.Collections.Generic;

namespace PartyManager.Application.Main.People.Queries.Models
{
    public class PersonDetailedDto : PersonDto
    {
        public string Email { get; set; }

        public string Phone { get; set; }

        public DrinkDto FavouriteDrink { get; set; }

        public IEnumerable<PartyGuestDto> PartiesAttendingAsGuest { get; set; }
    }
}
