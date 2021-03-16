using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.Application.Shared.DataAccess.Interfaces
{
    public interface IPartyGuestDataProvider
    {
        Task<IEnumerable<PartyGuest>> GetPartyGuests(int partyId);

        Task<int> InsertPartyGuest(InsertPartyGuestRequest request);

        Task UpdatePartyGuest(UpdatePartyGuestRequest request);

        Task DeletePartyGuest(int id);
    }
}