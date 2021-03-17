using PartyManager.Application.Main.Parties.Models;
using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.Parties.Queries
{
    public class GetParty : IQuery<PartyDto>
    {
        public int Id { get; set; }
    }
}