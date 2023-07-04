using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public bool IsCore { get; set; }
        [JsonIgnore]
        public virtual ICollection<Expanse> Expanses { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserCategory> UserCategories { get; set; }

        public Category(string name, bool isCore)
        {
            Name = name.ToUpper();
            IsCore = isCore;
        }
    }
}
