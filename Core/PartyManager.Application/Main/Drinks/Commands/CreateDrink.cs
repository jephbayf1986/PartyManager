using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.Drinks.Commands
{
    public class CreateDrink : ICommand<int>
    {
        public string Name { get; set; }
    }
}