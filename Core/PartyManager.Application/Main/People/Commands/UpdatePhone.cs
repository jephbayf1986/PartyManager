using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.People.Commands
{
    public class UpdatePhone : ICommand
    {
        public int Id { get; set; }

        public string Phone { get; set; }
    }
}