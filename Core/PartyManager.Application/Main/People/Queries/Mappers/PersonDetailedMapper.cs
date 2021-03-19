using PartyManager.Application.Main.Drinks.Queries.Mappers;
using PartyManager.Application.Main.Drinks.Queries.Models;
using PartyManager.Application.Main.People.Queries.Models;
using PartyManager.Application.Shared.Mapping;
using PartyManager.Domain;

namespace PartyManager.Application.Main.People.Queries.Mappers
{
    internal class PersonDetailedMapper : IMapper<Person, PersonDetailedDto>
    {
        public PersonDetailedDto Map(Person entityIn)
        {
            var person =  new PersonDetailedDto
            {
                Id = entityIn.Id,
                FirstName = entityIn.FirstName,
                LastName = entityIn.LastName,
                DateOfBirth = entityIn.DateOfBirth,
                Email = entityIn.Email,
                Phone = entityIn.Phone
            };

            if (entityIn.FavouriteDrink != null)
            {
                person.FavouriteDrink = entityIn.FavouriteDrink.Map()
                                                        .To<DrinkDto>()
                                                        .WithMapper<DrinkMapper>();
            }

            return person;
        }
    }
}