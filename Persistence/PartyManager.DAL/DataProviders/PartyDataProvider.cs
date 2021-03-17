using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.DataAccess.Models;
using PartyManager.Application.Shared.DataAccess.Requests;
using PartyManager.DAL.DatabaseEntities;
using PartyManager.DAL.Helpers;
using PartyManager.DAL.Infrastructure;
using PartyManager.DAL.Mappers;
using PartyManager.DAL.Mappers.Extensions;
using PartyManager.Domain;
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
            var param = ParamBuilder.None;

            var mapper = PartySummaryMapper.Mapper;

            return db.GetList(param, mapper);
        }

        public Task<Party> GetPartyDetail(int partyId)
        {
            var param = new ParamBuilder()
                                .WithPartyId(partyId);

            var mapper = PartyMapper.Mapper;

            return db.GetSingle(param, mapper);
        }

        public async Task<int> InsertParty(InsertPartyRequest request)
        {
            var param = new ParamBuilder()
                                .WithParam("Name", request.Name)
                                .WithParam("Location", request.Location)
                                .WithParam("StartTime", request.StartTime);

            var newId = await db.Insert(param);

            return newId.ToInt();
        }

        public Task UpdateParty(UpdatePartyRequest request)
        {
            var param = new ParamBuilder()
                                .WithPartyId(request.Id)
                                .WithParam("Name", request.Name)
                                .WithParam("Location", request.Location)
                                .WithParam("StartTime", request.StartTime);

            return db.Update(param);
        }
    }
}