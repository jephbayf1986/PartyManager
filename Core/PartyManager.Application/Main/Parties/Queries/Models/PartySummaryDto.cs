using System;

namespace PartyManager.Application.Main.Parties.Queries.Models
{
    public class PartySummaryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public int NumberOfGuests { get; set; }

        public int NumberOfVIPs { get; set; }

        public int NumberOfDrinkChoicesOutstanding { get; set; }
    }
}