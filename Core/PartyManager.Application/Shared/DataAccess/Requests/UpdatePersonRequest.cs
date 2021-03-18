namespace PartyManager.Application.Shared.DataAccess.Requests
{
    public class UpdatePersonRequest
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? FavouriteDrinkId { get; set; }
    }
}