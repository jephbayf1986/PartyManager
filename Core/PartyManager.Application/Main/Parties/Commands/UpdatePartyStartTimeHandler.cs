using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Parties.Commands
{
    public class UpdatePartyStartTimeHandler : PartyBase, ICommandHandler<UpdatePartyStartTime, Response>
    {
        private readonly IPartyDataProvider _dataProvider;
        
        public UpdatePartyStartTimeHandler(IPartyDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdatePartyStartTime command)
        {
            var request = new UpdatePartyRequest()
            {
                Id = command.Id,
                StartTime = command.StartTime
            };

            await _dataProvider.UpdateParty(request);

            return SuccessHandler.ReturnUpdateSuccess(EntityName);
        }
    }
}