namespace PartyManager.DAL.DatabaseEntities
{
    internal class PartyEntity : DatabaseEntity
    {
        public override string GetListSql => "spGetParties";

        public override string GetSingleSql => "spGetPartyDetail";

        public override string InsertSql => "spInsertParty";

        public override string UpdateSql => "spUpdateParty";
    }
}