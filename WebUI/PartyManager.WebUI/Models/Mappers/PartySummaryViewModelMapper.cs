using PartyManager.Application.Main.Parties.Models;
using PartyManager.Application.Shared.Mapping;

namespace PartyManager.WebUI.Models.Mappers
{
    public class PartySummaryViewModelMapper : IMapper<PartySummaryDto, PartySummaryViewModel>
    {
        public PartySummaryViewModel Map(PartySummaryDto entityIn)
        {
            return new PartySummaryViewModel
            {
                Id = entityIn.Id,
                Name = entityIn.Name,
                Location = entityIn.Location,
                StartTime = entityIn.StartTime,
                NumberOfGuests = entityIn.NumberOfGuests,
                NumberOfVIPs = entityIn.NumberOfVIPs,
                NumberOfDrinkChoicesOutstanding = entityIn.NumberOfDrinkChoicesOutstanding
            };
        }
    }
}