using PartyManager.Application.Main.Parties.Queries.Models;
using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.Exceptions;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Parties.Queries
{
    public class GetPartyHandler : PartyBase, IQueryHandler<GetParty, PartyDto>
    {
        private readonly IPartyDataProvider _partyProvider;
        private readonly IPartyGuestDataProvider _guestProvider;

        public GetPartyHandler(IPartyDataProvider partyProvider, IPartyGuestDataProvider guestProvider)
        {
            _partyProvider = partyProvider;
            _guestProvider = guestProvider;
        }

        public async Task<PartyDto> Handle(GetParty command)
        {
            var party = await _partyProvider.GetPartyDetail(command.Id);

            if (party == null)
            {
                throw new NotFoundException(command.Id, EntityName);
            }

            var guests = await _guestProvider.GetPartyGuests(command.Id);

            return new PartyDto
            {
                Id = party.Id,
                Name = party.Name,
                Location = party.Location,
                StartTime = party.StartTime,
                PartyGuests = guests
            };
        }
    }
}