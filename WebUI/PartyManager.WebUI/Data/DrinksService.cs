using PartyManager.Application;
using PartyManager.Application.Main.Drinks.Commands;
using PartyManager.Application.Main.Drinks.Queries;
using PartyManager.Application.Main.Drinks.Queries.Models;
using PartyManager.Application.Shared.Responding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.WebUI.Data
{
    public class DrinksService
    {
        private readonly IApplicationLayer _appLayer;

        public DrinksService(IApplicationLayer appLayer)
        {
            _appLayer = appLayer;
        }

        public Task<IEnumerable<DrinkDto>> GetDrinks()
        {
            return _appLayer.Get(new AllDrinks());
        }

        public Task<Response<int>> CreateDrink(CreateDrink command)
        {
            return _appLayer.Execute(command);
        }
    }
}