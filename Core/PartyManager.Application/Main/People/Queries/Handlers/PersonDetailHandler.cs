using PartyManager.Application.Main.Parties.Queries.Mappers;
using PartyManager.Application.Main.Parties.Queries.Models;
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
        private readonly IPersonDataProvider _personProvider;
        private readonly IPartyGuestDataProvider _partyGuestProvider;

        public PersonDetailHandler(IPersonDataProvider personProvider, IPartyGuestDataProvider partyGuestProvider)
        {
            _personProvider = personProvider;
            _partyGuestProvider = partyGuestProvider;
        }

        public async Task<PersonDetailedDto> Handle(PersonDetail command)
        {
            var person = await _personProvider.GetPersonInfo(command.Id);

            if (person == null)
            {
                throw new NotFoundException(command.Id, EntityName);
            }

            var dto = person.Map()
                            .To<PersonDetailedDto>()
                            .WithMapper<PersonDetailedMapper>();

            var guestApperances = await _partyGuestProvider.GetPartyGuestByPersonId(command.Id);

            dto.PartiesAttendingAsGuest = guestApperances.Map()
                                                         .ToEnumerable<PartyGuestDto>()
                                                         .WithMapper<PartyGuestMapper>();

            return dto;
        }
    }
}