using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.PartyGuests.Commands.Handlers
{
    public class UpdateChosenDrinkHandler : PartyGuestBase, ICommandHandler<UpdateChosenDrink, Response>
    {
        private readonly IPartyGuestDataProvider _dataProvider;

        public UpdateChosenDrinkHandler(IPartyGuestDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdateChosenDrink command)
        {
            var request = new UpdatePartyGuestRequest
            {
                Id = command.Id,
                ChosenDrinkId = command.ChosenDrinkId
            };

            await _dataProvider.UpdatePartyGuest(request);

            return SuccessHandler.ReturnUpdateSuccess(EntityName);
        }
    }
}