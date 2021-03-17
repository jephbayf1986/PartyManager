using PartyManager.Domain;

namespace PartyManager.DAL.Mappers.Helpers
{
    internal static class NullHelper
    {
        public static Drink NullableDrink(int? drinkId, string drinkName)
        {
            if (drinkId == null)
            {
                return null;
            }

            return new Drink
            {
                Id = drinkId.Value,
                Name = drinkName
            };
        }
    }
}