using PartyManager.Application.Main.People.Queries.Mappers;
using PartyManager.Application.Main.People.Queries.Models;
using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.Exceptions;
using PartyManager.Application.Shared.Mapping;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.People.Queries.Handlers
{
    public class PersonDetailHandler : PersonBase, IQueryHandler<PersonDetail, PersonDetailedDto>
    {
        private readonly IPersonDataProvider _dataProvider;

        public PersonDetailHandler(IPersonDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<PersonDetailedDto> Handle(PersonDetail command)
        {
            var person = await _dataProvider.GetPersonInfo(command.Id);

            if (person == null)
            {
                throw new NotFoundException(command.Id, EntityName);
            }

            return person.Map()
                         .To<PersonDetailedDto>()
                         .WithMapper<PersonDetailedMapper>();
        }
    }
}