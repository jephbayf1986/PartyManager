namespace PartyManager.Application.Shared.DataAccess.Requests
{
    public class UpdatePartyGuestRequest
    {
        public int Id { get; set; }

        public int? ChosenDrinkId { get; set; }

        public bool? IsVIP { get; set; }
    }
}