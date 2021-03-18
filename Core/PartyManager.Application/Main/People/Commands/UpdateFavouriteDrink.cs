using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.People.Commands
{
    public class UpdateFavouriteDrink : ICommand
    {
        public int Id { get; set; }
        
        public int FavouriteDrinkId { get; set; }
    }
}