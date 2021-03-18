using PartyManager.Application.Main.People.Queries.Mappers;
using PartyManager.Application.Main.People.Queries.Models;
using PartyManager.Application.Shared.CQRS;
using PartyManager.Application.Shared.DataAccess.Interfaces;
using PartyManager.Application.Shared.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.Application.Main.People.Queries.Handlers
{
    public class AllPeopleHandler : IQueryHandler<AllPeople, IEnumerable<PersonDto>>
    {
        private readonly IPersonDataProvider _dataProvider;

        public AllPeopleHandler(IPersonDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public async Task<IEnumerable<PersonDto>> Handle(AllPeople command)
        {
            var people = await _dataProvider.GetPeople();

            return people.Map()
                         .ToEnumerable<PersonDto>()
                         .WithMapper<PersonMapper>();
        }
    }
}