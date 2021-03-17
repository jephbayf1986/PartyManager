namespace PartyManager.DAL.DatabaseEntities
{
    internal class DrinkEntity : DatabaseEntity
    {
        public override string GetListSql => "spGetDrinks";

        public override string InsertSql => "spInsertDrink";
    }
}