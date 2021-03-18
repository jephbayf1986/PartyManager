using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.PartyGuests.Commands
{
    public class RemoveGuest : ICommand
    {
        public int Id { get; set; }
    }
}