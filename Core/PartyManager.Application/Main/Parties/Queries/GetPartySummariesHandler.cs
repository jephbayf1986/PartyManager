using PartyManager.Application.Main.Parties.Mappers;
using PartyManager.Application.Main.Parties.Models;
using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.Mapping;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Parties.Queries
{
    public class GetPartySummariesHandler : IQueryHandler<GetPartySummaries, IEnumerable<PartySummaryDto>>
    {
        private readonly IPartyDataProvider _dataProvider;
        
        public GetPartySummariesHandler(IPartyDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<IEnumerable<PartySummaryDto>> Handle(GetPartySummaries command, CancellationToken token = default)
        {
            var summaries = await _dataProvider.GetParties();

            return summaries.Map()
                            .ToEnumerable<PartySummaryDto>()
                            .WithMapper<PartySummaryMapper>();
        }
    }
}