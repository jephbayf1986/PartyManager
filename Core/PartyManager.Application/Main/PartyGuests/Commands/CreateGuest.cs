using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.PartyGuests.Commands
{
    public class CreateGuest : ICommand<int>
    {
        public int PartyId { get; set; }

        public int PersonId { get; set; }

        public int? ChosenDrinkId { get; set; }

        public bool IsVip { get; set; }
    }
}