namespace PartyManager.DAL.DatabaseEntities
{
    internal abstract class DatabaseEntity
    {
        public virtual string GetListSql => null;

        public virtual string GetSingleSql => null;

        public virtual string InsertSql => null;

        public virtual string UpdateSql => null;

        public virtual string DeleteSql => null;
    }
}