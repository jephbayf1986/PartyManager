namespace PartyManager.DAL.DatabaseEntities
{
    internal class PartyGuestEntity : DatabaseEntity
    {
        public override string GetListSql => "spGetPartyGuests";

        public override string InsertSql => "spInsertPartyGuest";

        public override string UpdateSql => "spUpdatePartyGuest";

        public override string DeleteSql => "spDeletePartyGuest";
    }
}