namespace Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool Deleted { get; set; } = false;
    }
}
