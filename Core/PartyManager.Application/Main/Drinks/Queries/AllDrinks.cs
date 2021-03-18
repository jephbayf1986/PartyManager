using PartyManager.Application.Main.Drinks.Queries.Models;
using PartyManager.Application.Shared.CQRS;
using System.Collections.Generic;

namespace PartyManager.Application.Main.Drinks.Queries
{
    public class AllDrinks : IQuery<IEnumerable<DrinkDto>>
    {
    }
}