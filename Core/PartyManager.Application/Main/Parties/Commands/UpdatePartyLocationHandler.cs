using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Parties.Commands
{
    public class UpdatePartyLocationHandler : PartyBase, ICommandHandler<UpdatePartyLocation, Response>
    {
        private readonly IPartyDataProvider _dataProvider;

        public UpdatePartyLocationHandler(IPartyDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdatePartyLocation command)
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