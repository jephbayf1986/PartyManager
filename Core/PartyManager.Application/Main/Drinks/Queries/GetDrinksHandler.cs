using PartyManager.Application.Main.Drinks.Queries.Mappers;
using PartyManager.Application.Main.Drinks.Queries.Models;
using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Drinks.Queries
{
    public class GetDrinksHandler : IQueryHandler<GetDrinks, IEnumerable<DrinkDto>>
    {
        private readonly IDrinkDataProvider _dataProvider;

        public GetDrinksHandler(IDrinkDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<IEnumerable<DrinkDto>> Handle(GetDrinks command)
        {
            var drinks = await _dataProvider.GetDrinks();

            return drinks.Map()
                         .ToEnumerable<DrinkDto>()
                         .WithMapper<DrinkMapper>();
        }
    }
}