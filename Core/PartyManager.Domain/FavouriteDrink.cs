namespace PartyManager.Domain
{
    public class FavouriteDrink
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public int DrinkId { get; set; }

        public Drink Drink { get; set; }
    }
}