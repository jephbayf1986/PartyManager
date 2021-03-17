using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.DAL.DatabaseEntities;
using PartyManager.DAL.Infrastructure;
using PartyManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyManager.DAL.DataProviders
{
    public class PartyGuestDataProvider : IPartyGuestDataProvider
    {
        private readonly IDbEntity<PartyGuestEntity> db;
        
        public PartyGuestDataProvider(IDbCore dbCore)
        {
            db = new DbEntity<PartyGuestEntity>(dbCore);
        }

        public Task<IEnumerable<PartyGuest>> GetPartyGuests(int partyId)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertPartyGuest(InsertPartyGuestRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePartyGuest(UpdatePartyGuestRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeletePartyGuest(int id)
        {
            throw new NotImplementedException();
        }
    }
}