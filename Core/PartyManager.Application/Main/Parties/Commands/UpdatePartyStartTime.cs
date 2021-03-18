using PartyManager.Application.Shared.CQRS;
using System;

namespace PartyManager.Application.Main.Parties.Commands
{
    public class UpdatePartyStartTime : ICommand
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }
    }
}