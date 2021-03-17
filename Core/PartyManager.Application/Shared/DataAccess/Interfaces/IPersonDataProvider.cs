using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.Application.Shared.DataAccess.Interfaces
{
    public interface IPersonDataProvider
    {
        Task<IEnumerable<Person>> GetPeople();

        Task<Person> GetPersonInfo(int id);

        Task<int> InsertPerson(InsertPersonRequest request);

        Task UpdatePerson(UpdatePersonRequest request);
    }
}