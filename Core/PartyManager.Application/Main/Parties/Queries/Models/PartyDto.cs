using PartyManager.Domain;
using System;
using System.Collections.Generic;

namespace PartyManager.Application.Main.Parties.Queries.Models
{
    public class PartyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public IEnumerable<PartyGuestDto> PartyGuests { get; set; }
    }
}