using PartyManager.Application.Main.Parties.Queries.Models;
using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.Parties.Queries
{
    public class PartyDetail : IQuery<PartyDto>
    {
        public int Id { get; set; }
    }
}