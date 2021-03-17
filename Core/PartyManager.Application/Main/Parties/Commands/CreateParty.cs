using PartyManager.Application.Shared.CQRS;
using System;

namespace PartyManager.Application.Main.Parties.Commands
{
    public class CreateParty : ICommand<int>
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }
    }
}