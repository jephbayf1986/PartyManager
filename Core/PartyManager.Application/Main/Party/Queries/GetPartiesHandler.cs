using PartyManager.Application.Main.Party.Models;
using PartyManager.Application.Shared.CQRS;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.Party.Queries
{
    public class GetPartiesHandler : IQueryHandler<GetParties, IEnumerable<PartyDto>>
    {
        public Task<IEnumerable<PartyDto>> Handle(GetParties command, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}