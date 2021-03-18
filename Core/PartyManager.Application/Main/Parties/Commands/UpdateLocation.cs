using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.Parties.Commands
{
    public class UpdateLocation : ICommand
    {
        public int Id { get; set; }

        public string Location { get; set; }
    }
}