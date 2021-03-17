using PartyManager.Application.Shared.CQRS;
using System;

namespace PartyManager.Application.Main.Parties.Commands
{
    public class UpdateParty : ICommand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime? StartTime { get; set; }
    }
}