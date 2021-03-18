using PartyManager.Application.Main.Parties.Queries.Mappers;
using PartyManager.Application.Main.Parties.Queries.Models;
using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.Mapping;
using System.Collections.Generic;
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

        public async Task<IEnumerable<PartySummaryDto>> Handle(GetPartySummaries command)
        {
            var summaries = await _dataProvider.GetParties();

            return summaries.Map()
                            .ToEnumerable<PartySummaryDto>()
                            .WithMapper<PartySummaryMapper>();
        }
    }
}