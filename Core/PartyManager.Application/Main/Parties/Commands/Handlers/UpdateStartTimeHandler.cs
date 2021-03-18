using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Parties.Commands.Handlers
{
    public class UpdateStartTimeHandler : PartyBase, ICommandHandler<UpdateStartTime, Response>
    {
        private readonly IPartyDataProvider _dataProvider;
        
        public UpdateStartTimeHandler(IPartyDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdateStartTime command)
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