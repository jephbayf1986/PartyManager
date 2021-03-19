namespace PartyManager.DAL.DatabaseEntities
{
    internal class PartyGuestByPersonEntity : DatabaseEntity
    {
        public override string GetListSql => "spGetPartiesByPerson";
    }
}