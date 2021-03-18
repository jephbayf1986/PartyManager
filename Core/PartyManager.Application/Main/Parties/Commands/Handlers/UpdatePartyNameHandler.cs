using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Parties.Commands.Handlers
{
    public class UpdatePartyNameHandler : PartyBase, ICommandHandler<UpdatePartyName, Response>
    {
        private readonly IPartyDataProvider _dataProvider;

        public UpdatePartyNameHandler(IPartyDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(UpdatePartyName command)
        {
            var request = new UpdatePartyRequest()
            {
                Id = command.Id,
                Name = command.Name
            };

            await _dataProvider.UpdateParty(request);

            return SuccessHandler.ReturnUpdateSuccess(EntityName);
        }
    }
}