using PartyManager.Application;
using PartyManager.Application.Main.Parties.Commands;
using PartyManager.Application.Main.Parties.Queries;
using PartyManager.Application.Main.Parties.Queries.Models;
using PartyManager.Application.Shared.Responding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.WebUI.Data
{
    public class PartySummaryService
    {
        private readonly IApplicationLayer _appLayer;

        public PartySummaryService(IApplicationLayer appLayer)
        {
            _appLayer = appLayer;
        }

        public Task<IEnumerable<PartySummaryDto>> GetPartySummaries()
        {
            return _appLayer.Get(new AllPartiesSummarised());
        }

        public Task<Response<int>> CreateParty(CreateParty command)
        {
            return _appLayer.Execute(command);
        }
    }
}
