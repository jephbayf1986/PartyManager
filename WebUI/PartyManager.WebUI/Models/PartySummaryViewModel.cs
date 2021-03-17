using System;

namespace PartyManager.WebUI.Models
{
    public class PartySummaryViewModel
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
