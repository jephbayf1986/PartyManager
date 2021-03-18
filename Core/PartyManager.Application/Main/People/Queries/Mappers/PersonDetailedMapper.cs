using PartyManager.Application.Main.Drinks.Queries.Mappers;
using PartyManager.Application.Main.Drinks.Queries.Models;
using PartyManager.Application.Main.People.Queries.Models;
using PartyManager.Application.Shared.Mapping;
using PartyManager.Domain;
using System;

namespace PartyManager.Application.Main.People.Queries.Mappers
{
    internal class PersonDetailedMapper : IMapper<Person, PersonDetailedDto>
    {
        public PersonDetailedDto Map(Person entityIn)
        {
            return new PersonDetailedDto
            {
                Id = entityIn.Id,
                FirstName = entityIn.FirstName,
                LastName = entityIn.LastName,
                DateOfBirth = entityIn.DateOfBirth,
                Email = entityIn.Email,
                Phone = entityIn.Phone,
                FavouriteDrink = entityIn.FavouriteDrink.Map()
                                                        .To<DrinkDto>()
                                                        .WithMapper<DrinkMapper>()
            };
        }
    }
}