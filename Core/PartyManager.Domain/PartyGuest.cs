namespace PartyManager.Domain
{
    public class PartyGuest
    {
        public int Id { get; set; }

        public int PartyId { get; set; }

        public int PersonId { get; set; }

        public int? ChosenDrinkId { get; set; }

        public bool IsVIP { get; set; }

        public Party Party { get; set; }

        public Person Person { get; set; }

        public Drink ChosenDrink { get; set; }
    }
}