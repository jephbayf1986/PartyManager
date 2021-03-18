using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Parties.Commands.Handlers
{
    public class UpdateLocationHandler : PartyBase, ICommandHandler<UpdateLocation, Response>
    {
        private readonly IPartyDataProvider _dataProvider;

        public UpdateLocationHandler(IPartyDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdateLocation command)
        {
            var request = new UpdatePartyRequest()
            {
                Id = command.Id,
                Location = command.Location
            };

            await _dataProvider.UpdateParty(request);

            return SuccessHandler.ReturnUpdateSuccess(EntityName);
        }
    }
}