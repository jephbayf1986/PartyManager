using PartyManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.Application.Shared.DataAccess.Interfaces
{
    public interface IDrinkDataProvider
    {
        Task<IEnumerable<Drink>> GetDrinks();

        Task<int> InsertDrink(string name);
    }
}