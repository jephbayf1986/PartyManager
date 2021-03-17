namespace PartyManager.DAL.DatabaseEntities
{
    internal class PersonEntity : DatabaseEntity
    {
        public override string GetListSql => "spGetPeople";

        public override string GetSingleSql => "spGetPersonInfo";

        public override string InsertSql => "spInsertPerson";

        public override string UpdateSql => "spUpdatePerson";
    }
}