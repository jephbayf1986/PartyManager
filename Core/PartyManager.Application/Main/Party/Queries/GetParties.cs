using PartyManager.Application.Main.Party.Models;
using PartyManager.Application.Shared.CQRS;
using System.Collections.Generic;

namespace PartyManager.Application.Main.Party.Queries
{
    public class GetParties : IQuery<IEnumerable<PartyDto>>
    {
    }
}