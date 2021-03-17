using PartyManager.Application.Shared.DataAccess.Interfaces;
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
    public class DrinkDataProvider : IDrinkDataProvider
    {
        private readonly IDbEntity<DrinkEntity> db;

        public DrinkDataProvider(IDbCore dbCore)
        {
            db = new DbEntity<DrinkEntity>(dbCore);
        }

        public Task<IEnumerable<Drink>> GetDrinks()
        {
            var param = ParamBuilder.None;

            var mapper = DrinkMapper.Mapper;

            return db.GetList(param, mapper);
        }

        public async Task<int> InsertDrink(string name)
        {
            var param = new ParamBuilder()
                                .WithParam("Name", name);

            var newId = await db.Insert(param);

            return newId.ToInt();
        }
    }
}