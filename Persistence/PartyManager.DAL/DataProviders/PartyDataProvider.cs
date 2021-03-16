using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Models;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.DAL.DatabaseEntities;
using PartyManager.DAL.Infrastructure;
using PartyManager.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.DAL.DataProviders
{
    public class PartyDataProvider : IPartyDataProvider, IDataProvider
    {
        private readonly IDbEntity<PartyEntity> db;

        public PartyDataProvider(IDbCore dbCore)
        {
            db = new DbEntity<PartyEntity>(dbCore);
        }

        public Task<IEnumerable<PartySummary>> GetParties()
        {
            return db.GetList<PartySummary>(null, null);
        }

        public Task<Party> GetPartyDetail(int partyId)
        {
            return db.GetSingle<Party>(null, null);
        }

        public Task<int> InsertParty(InsertPartyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateParty(UpdatePartyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}