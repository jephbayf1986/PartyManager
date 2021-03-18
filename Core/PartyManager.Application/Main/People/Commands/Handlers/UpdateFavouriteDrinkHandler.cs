using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.People.Commands.Handlers
{
    public class UpdateFavouriteDrinkHandler : PersonBase, ICommandHandler<UpdateFavouriteDrink, Response>
    {
        private readonly IPersonDataProvider _dataProvider;

        public UpdateFavouriteDrinkHandler(IPersonDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdateFavouriteDrink command)
        {
            var request = new UpdatePersonRequest()
            {
                Id = command.Id,
                FavouriteDrinkId = command.FavouriteDrinkId
            };

            await _dataProvider.UpdatePerson(request);

            return SuccessHandler.ReturnUpdateSuccess(EntityName);
        }
    }
}