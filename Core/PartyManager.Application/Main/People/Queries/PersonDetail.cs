using PartyManager.Application.Main.People.Queries.Models;
using PartyManager.Application.Shared.CQRS;

namespace PartyManager.Application.Main.People.Queries
{
    public class PersonDetail : IQuery<PersonDetailedDto>
    {
        public int Id { get; set; }
    }
}