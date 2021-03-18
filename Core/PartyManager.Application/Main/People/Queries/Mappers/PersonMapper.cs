using PartyManager.Application.Main.People.Queries.Models;
using PartyManager.Application.Shared.Mapping;
using PartyManager.Domain;

namespace PartyManager.Application.Main.People.Queries.Mappers
{
    internal class PersonMapper : IMapper<Person, PersonDto>
    {
        public PersonDto Map(Person entityIn)
        {
            return new PersonDto
            {
                Id = entityIn.Id,
                FirstName = entityIn.FirstName,
                LastName = entityIn.LastName,
                DateOfBirth = entityIn.DateOfBirth
            };
        }
    }
}