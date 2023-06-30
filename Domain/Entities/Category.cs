namespace Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public bool IsCore { get; set; }
        public virtual ICollection<Expanse> Expanses { get; set; }
        public virtual ICollection<UserCategory> UserCategories { get; set; }

        public Category(string name, bool isCore)
        {
            Name = name.ToUpper();
            IsCore = isCore;
        }
    }
}
