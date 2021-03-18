using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Parties.Commands.Handlers
{
    public class CreatePartyHandler : PartyBase, ICommandHandler<CreateParty, Response<int>>
    {
        private readonly IPartyDataProvider _dataProvider;

        public CreatePartyHandler(IPartyDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response<int>> Handle(CreateParty command)
        {
            var request = new InsertPartyRequest 
            { 
                Name = command.Name,
                Location = command.Location,
                StartTime = command.StartTime
            };

            var newPartyId = await _dataProvider.InsertParty(request);

            return SuccessHandler.ReturnInsertSuccess(newPartyId, EntityName);
        }
    }
}
