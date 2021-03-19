using PartyManager.Application.Main.Drinks.Queries.Models;
using PartyManager.Application.Main.Parties.Queries.Models;
using PartyManager.Application.Main.People.Queries.Mappers;
using PartyManager.Application.Main.People.Queries.Models;
using PartyManager.Application.Shared.Mapping;
using PartyManager.Domain;

namespace PartyManager.Application.Main.Parties.Queries.Mappers
{
    internal class PartyGuestMapper : IMapper<PartyGuest, PartyGuestDto>
    {
        public PartyGuestDto Map(PartyGuest entityIn)
        {
            var guest = new PartyGuestDto
            {
                Id = entityIn.Id,
                PartyId = entityIn.PartyId,
                PersonId = entityIn.PersonId,
                IsVIP = entityIn.IsVIP,
                ChosenDrinkId = entityIn.ChosenDrinkId,
                Party = new PartyDto
                {
                    Id = entityIn.PartyId,
                    Name = entityIn.Party.Name,
                    Location = entityIn.Party.Location,
                    StartTime = entityIn.Party.StartTime
                },
                Person = entityIn.Person.Map()
                                        .To<PersonDto>()
                                        .WithMapper<PersonMapper>()
            };

            if (entityIn.ChosenDrink != null)
            {
                guest.ChosenDrink = new DrinkDto
                {
                    Id = entityIn.ChosenDrink.Id,
                    Name = entityIn.ChosenDrink.Name
                };
            }

            return guest;
        }
    }
}