using PartyManager.Application.Main.People.Queries.Models;
using PartyManager.Application.Shared.CQRS;
using System.Collections.Generic;

namespace PartyManager.Application.Main.People.Queries
{
    public class AllPeople : IQuery<IEnumerable<PersonDto>>
    {
    }
}