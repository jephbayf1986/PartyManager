using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.PartyGuests.Commands.Handlers
{
    public class CreateGuestHandler : PartyGuestBase, ICommandHandler<CreateGuest, Response<int>>
    {
        private readonly IPartyGuestDataProvider _dataProvider;

        public CreateGuestHandler(IPartyGuestDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response<int>> Handle(CreateGuest command)
        {
            var request = new InsertPartyGuestRequest
            {
                PartyId = command.PartyId,
                PersonId = command.PersonId,
                ChosenDrinkId = command.ChosenDrinkId,
                IsVIP = command.IsVip
            };

            var newPartyId = await _dataProvider.InsertPartyGuest(request);

            return SuccessHandler.ReturnInsertSuccess(newPartyId, EntityName);
        }
    }
}