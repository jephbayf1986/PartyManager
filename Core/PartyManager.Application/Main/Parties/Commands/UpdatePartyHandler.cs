using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Parties.Commands
{
    public class UpdatePartyHandler : PartyBase, ICommandHandler<UpdateParty, Response>
    {
        private readonly IPartyDataProvider _dataProvider;

        public UpdatePartyHandler(IPartyDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdateParty command, CancellationToken token = default)
        {
            var request = new UpdatePartyRequest()
            {
                Id = command.Id,
                Name = command.Name,
                Location = command.Location,
                StartTime = command.StartTime
            };

            await _dataProvider.UpdateParty(request);

            return SuccessHandler.ReturnUpdateSuccess(EntityName);
        }
    }
}