﻿using PartyManager.Application;
using PartyManager.Application.Main.People.Queries;
using PartyManager.Application.Main.People.Queries.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PartyManager.WebUI.Data
{
    public class PeopleService
    {
        private readonly IApplicationLayer _appLayer;

        public PeopleService(IApplicationLayer appLayer)
        {
            _appLayer = appLayer;
        }

        public Task<IEnumerable<PersonDto>> GetPeople()
        {
            return _appLayer.Get(new AllPeople());
        }
    }
}
