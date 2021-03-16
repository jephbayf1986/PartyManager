using PartyManager.Application.Shared.DataAccess.Models;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.Application.Shared.DataAccess.Interfaces
{
    public interface IPartyDataProvider
    {
        Task<IEnumerable<PartySummary>> GetParties();
        
        Task<Party> GetPartyDetail(int partyId);

        Task<int> InsertParty(InsertPartyRequest request);

        Task UpdateParty(UpdatePartyRequest request);
    }
}