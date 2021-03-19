using PartyManager.Application;
using PartyManager.Application.Main.People.Commands;
using PartyManager.Application.Main.People.Queries;
using PartyManager.Application.Main.People.Queries.Models;
using PartyManager.Application.Shared.Responding;
using System.Threading.Tasks;

namespace PartyManager.WebUI.Data
{
    public class PersonAdminService
    {
        private readonly IApplicationLayer _appLayer;

        public PersonAdminService(IApplicationLayer appLayer)
        {
            _appLayer = appLayer;
        }

        public Task<PersonDetailedDto> GetPersonDetail(int Id)
        {
            return _appLayer.Get(new PersonDetail { Id = Id });
        }

        public Task<Response> UpdateEmail(UpdateEmail command)
        {
            return _appLayer.Execute(command);
        }

        public Task<Response> UpdatePhone(UpdatePhone command)
        {
            return _appLayer.Execute(command);
        }

        public Task<Response> UpdateFavouriteDrink(UpdateFavouriteDrink command)
        {
            return _appLayer.Execute(command);
        }
    }
}