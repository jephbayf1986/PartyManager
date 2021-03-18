using PartyManager.Application.Shared.CQRS;
using System;

namespace PartyManager.Application.Main.Parties.Commands
{
    public class UpdatePartyName : ICommand
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}