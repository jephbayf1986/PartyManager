using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.PartyGuests.Commands.Handlers
{
    public class RemoveGuestHandler : PartyGuestBase, ICommandHandler<RemoveGuest, Response>
    {
        private readonly IPartyGuestDataProvider _dataProvider;

        public RemoveGuestHandler(IPartyGuestDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<Response> Handle(RemoveGuest command)
        {
            await _dataProvider.DeletePartyGuest(command.Id);

            return SuccessHandler.ReturnDeleteSuccess(EntityName);
        }
    }
}