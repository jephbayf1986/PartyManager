using PartyManager.Application.Main.Drinks.Queries.Models;
using PartyManager.Application.Main.People.Queries.Models;

namespace PartyManager.Application.Main.Parties.Queries.Models
{
    public class PartyGuestDto
    {
        public int Id { get; set; }

        public int PartyId { get; set; }

        public int PersonId { get; set; }

        public int? ChosenDrinkId { get; set; }

        public bool IsVIP { get; set; }

        public PartyDto Party { get; set; }

        public PersonDto Person { get; set; }

        public DrinkDto ChosenDrink { get; set; }
    }
}