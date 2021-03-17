using PartyManager.Domain;

namespace PartyManager.Application.Shared.DataAccess.Models
{
    public class PartySummary
    {
        public Party Party { get; set; }

        public int NumberOfGuests { get; set; }

        public int NumberOfVIPs { get; set; }

        public int NumberOfDrinkChoicesOutstanding { get; set; }
    }
}