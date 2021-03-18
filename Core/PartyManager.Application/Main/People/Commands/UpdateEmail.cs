using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.People.Commands
{
    public class UpdateEmail : ICommand
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
    }
}