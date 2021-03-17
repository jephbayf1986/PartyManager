using PartyManager.Application.Main.Parties.Models;
using PartyManager.Application.Shared.DataAccess.Models;
using PartyManager.Application.Shared.Mapping;

namespace PartyManager.Application.Main.Parties.Mappers
{
    internal class PartySummaryMapper : IMapper<PartySummary, PartySummaryDto>
    {
        public PartySummaryDto Map(PartySummary entityIn)
        {
            return new PartySummaryDto
            {
                Id = entityIn.Party.Id,
                Name = entityIn.Party.Name,
                Location = entityIn.Party.Location,
                StartTime = entityIn.Party.StartTime,
                NumberOfGuests = entityIn.NumberOfGuests,
                NumberOfVIPs = entityIn.NumberOfVIPs,
                NumberOfDrinkChoicesOutstanding = entityIn.NumberOfDrinkChoicesOutstanding
            };
        }
    }
}