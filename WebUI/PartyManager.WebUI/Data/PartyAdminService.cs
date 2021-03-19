using PartyManager.Application;
using PartyManager.Application.Main.Parties.Commands;
using PartyManager.Application.Main.Parties.Queries;
using PartyManager.Application.Main.Parties.Queries.Models;
using PartyManager.Application.Main.PartyGuests.Commands;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.WebUI.Data
{
    public class PartyAdminService
    {
        private readonly IApplicationLayer _appLayer;

        public PartyAdminService(IApplicationLayer appLayer)
        {
            _appLayer = appLayer;
        }

        public Task<PartyDto> GetParty(int Id)
        {
            return _appLayer.Get(new PartyDetail { Id = Id });
        }

        public Task<Response> UpdateName(UpdatePartyName command)
        {
            return _appLayer.Execute(command);
        }

        public Task<Response> UpdateLocation(UpdateLocation command)
        {
            return _appLayer.Execute(command);
        }

        public Task<Response> UpdateStartTime(UpdateStartTime command)
        {
            return _appLayer.Execute(command);
        }

        public Task<Response<int>> CreateGuest(CreateGuest command)
        {
            return _appLayer.Execute(command);
        }

        public Task<Response> RemoveGuest(RemoveGuest command)
        {
            return _appLayer.Execute(command);
        }
    }
}
