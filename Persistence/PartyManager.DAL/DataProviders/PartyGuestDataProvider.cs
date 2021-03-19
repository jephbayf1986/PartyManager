using PartyManager.Application.Shared.DataAccess.Interfaces;
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
    public class PartyGuestDataProvider : IPartyGuestDataProvider
    {
        private readonly IDbEntity<PartyGuestEntity> db;
        private readonly IDbEntity<PartyGuestByPersonEntity> db_ByPerson;

        public PartyGuestDataProvider(IDbCore dbCore)
        {
            db = new DbEntity<PartyGuestEntity>(dbCore);
            db_ByPerson = new DbEntity<PartyGuestByPersonEntity>(dbCore);
        }

        public Task<IEnumerable<PartyGuest>> GetPartyGuests(int partyId)
        {
            var param = new ParamBuilder()
                                .WithPartyId(partyId);

            var mapper = PartyGuestMapper.Mapper;

            return db.GetList(param, mapper);
        }

        public Task<IEnumerable<PartyGuest>> GetPartyGuestByPersonId(int personId)
        {
            var param = new ParamBuilder()
                                .WithPersonId(personId);

            var mapper = PartyGuestMapper.Mapper;

            return db_ByPerson.GetList(param, mapper);
        }

        public async Task<int> InsertPartyGuest(InsertPartyGuestRequest request)
        {
            var param = new ParamBuilder()
                                .WithPartyId(request.PartyId)
                                .WithPersonId(request.PersonId)
                                .WithParam("ChosenDrinkId", request.ChosenDrinkId)
                                .WithParam("IsVIP", request.IsVIP);

            var newId = await db.Insert(param);

            return newId.ToInt();
        }

        public Task UpdatePartyGuest(UpdatePartyGuestRequest request)
        {
            var param = new ParamBuilder()
                                .WithPartyGuestId(request.Id)
                                .WithParam("ChosenDrinkId", request.ChosenDrinkId)
                                .WithParam("IsVIP", request.IsVIP);

            return db.Update(param);
        }

        public Task DeletePartyGuest(int id)
        {
            var param = new ParamBuilder()
                                .WithPartyGuestId(id);

            return db.Delete(param);
        }
    }
}