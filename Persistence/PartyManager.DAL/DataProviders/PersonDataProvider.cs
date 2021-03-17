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
    public class PersonDataProvider : IPersonDataProvider
    {
        private readonly IDbEntity<PersonEntity> db;

        public PersonDataProvider(IDbCore dbCore)
        {
            db = new DbEntity<PersonEntity>(dbCore);
        }

        public Task<IEnumerable<Person>> GetPeople()
        {
            var param = ParamBuilder.None;

            var mapper = PersonMapper.BasicMapper;

            return db.GetList(param, mapper);
        }

        public Task<Person> GetPersonInfo(int id)
        {
            var param = new ParamBuilder()
                                .WithPersonId(id);

            var mapper = PersonMapper.DetailedMapper;

            return db.GetSingle(param, mapper);
        }

        public async Task<int> InsertPerson(InsertPersonRequest request)
        {
            var param = new ParamBuilder()
                                .WithParam("FirstName", request.FirstName)
                                .WithParam("LastName", request.LastName)
                                .WithParam("DOB", request.DateOfBirth)
                                .WithParam("Email", request.Email)
                                .WithParam("Phone", request.Phone)
                                .WithParam("FavouriteDrinkId", request.FavouriteDrinkId);

            var newId = await db.Insert(param);

            return newId.ToInt();
        }

        public Task UpdatePerson(UpdatePersonRequest request)
        {
            var param = new ParamBuilder()
                                .WithPersonId(request.Id)
                                .WithParam("Email", request.Email)
                                .WithParam("Phone", request.Phone)
                                .WithParam("FavouriteDrinkId", request.FavouriteDrinkId);

            return db.Update(param);
        }
    }
}