using PartyManager.Application;
using PartyManager.Application.Main.PartyGuests.Commands;
using PartyManager.Application.Main.People.Commands;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.WebUI.Data
{
    public class GuestAdminService
    {
        private readonly IApplicationLayer _appLayer;

        public GuestAdminService(IApplicationLayer appLayer)
        {
            _appLayer = appLayer;
        }

        public Task<Response> UpdateChosenDrink(UpdateChosenDrink command)
        {
            return _appLayer.Execute(command);
        }

        // Give User choice to update along with above
        public Task<Response> UpdateFavouriteDrink(UpdateFavouriteDrink command)
        {
            return _appLayer.Execute(command);
        }

        public Task<Response> UpdateVipStatus(UpdateVipStatus command)
        {
            return _appLayer.Execute(command);
        }
    }
}
