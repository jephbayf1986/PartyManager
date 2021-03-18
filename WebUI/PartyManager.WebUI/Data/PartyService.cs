using PartyManager.Application;
using PartyManager.Application.Main.Parties.Models;
using PartyManager.Application.Main.Parties.Queries;
using PartyManager.Application.Shared.DataAccess.Models;
using PartyManager.Application.Shared.Mapping;
using PartyManager.WebUI.Models;
using PartyManager.WebUI.Models.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.WebUI.Data
{
    public class PartyService
    {
        private readonly IApplicationLayer _appLayer;

        public PartyService(IApplicationLayer appLayer)
        {
            _appLayer = appLayer;
        }

        public async Task<IEnumerable<PartySummaryViewModel>> GetPartySummaries()
        {
            var summaries = await _appLayer.Get(new AllPartiesSummarised());

            return summaries.Map()
                            .ToEnumerable<PartySummaryViewModel>()
                            .WithMapper<PartySummaryViewModelMapper>();
        }
    }
}
