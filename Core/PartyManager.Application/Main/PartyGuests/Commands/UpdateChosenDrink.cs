using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.PartyGuests.Commands
{
    public class UpdateChosenDrink : ICommand
    {
        public int Id { get; set; }

        public int ChosenDrinkId { get; set; }
    }
}