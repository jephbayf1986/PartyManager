namespace PartyManager.DAL.DatabaseEntities
{
    internal class PartyGuestEntity : DatabaseEntity
    {
        public override string GetListSql => "spGetPartyGuests";

        public override string GetSingleSql => base.GetSingleSql;

        public override string InsertSql => base.InsertSql;

        public override string UpdateSql => base.UpdateSql;

        public override string DeleteSql => base.DeleteSql;
    }
}