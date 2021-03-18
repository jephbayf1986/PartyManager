using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.Parties.Commands
{
    public class UpdatePartyLocation : ICommand
    {
        public int Id { get; set; }

        public string Location { get; set; }
    }
}