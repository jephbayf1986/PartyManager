using PartyManager.Application.Main.Drinks.Queries.Models;
using PartyManager.Application.Shared.Mapping;
using PartyManager.Domain;

namespace PartyManager.Application.Main.Drinks.Queries.Mappers
{
    internal class DrinkMapper : IMapper<Drink, DrinkDto>
    {
        public DrinkDto Map(Drink entityIn)
        {
            return new DrinkDto
            {
                Id = entityIn.Id,
                Name = entityIn.Name
            };
        }
    }
}