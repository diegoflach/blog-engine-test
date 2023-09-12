using System.Data;

namespace BlogEngineApi.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset Timestamp { get; protected set; }
        public DataRowVersion RowVersion { get; protected set; }

        protected Entity()
        {
            Timestamp = DateTimeOffset.Now;
            RowVersion = DataRowVersion.Default;
        }
    }
}