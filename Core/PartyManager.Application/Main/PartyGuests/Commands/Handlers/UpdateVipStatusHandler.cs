using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.PartyGuests.Commands.Handlers
{
    public class UpdateVipStatusHandler : PartyGuestBase, ICommandHandler<UpdateVipStatus, Response>
    {
        private readonly IPartyGuestDataProvider _dataProvider;

        public UpdateVipStatusHandler(IPartyGuestDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdateVipStatus command)
        {
            var request = new UpdatePartyGuestRequest
            {
                Id = command.Id,
                IsVIP = command.IsVip
            };

            await _dataProvider.UpdatePartyGuest(request);

            return SuccessHandler.ReturnUpdateSuccess(EntityName);
        }
    }
}