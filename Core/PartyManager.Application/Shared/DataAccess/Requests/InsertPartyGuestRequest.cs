namespace PartyManager.Application.Shared.DataAccess.Requests
{
    public class InsertPartyGuestRequest
    {
        public int PartyId { get; set; }

        public int PersonId { get; set; }

        public bool IsVIP { get; set; }

        public int? ChosenDrinkId { get; set; }
    }
}