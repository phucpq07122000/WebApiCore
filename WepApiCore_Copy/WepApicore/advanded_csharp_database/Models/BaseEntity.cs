namespace advanded_csharp_database.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        protected BaseEntity()
        {
            Id = Guid.Empty;
            CreatedAt = DateTimeOffset.UtcNow;
        }
    }
}
