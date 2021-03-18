using PartyManager.Application.Main.Parties.Queries.Models;
using PartyManager.Application.Shared.CQRS;
using System.Collections.Generic;

namespace PartyManager.Application.Main.Parties.Queries
{
    public class AllPartiesSummarised : IQuery<IEnumerable<PartySummaryDto>>
    {
    }
}