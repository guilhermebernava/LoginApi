using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Expanse : Entity
    {
        public string Title { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual AppUser User { get; set; }

        public Expanse(string title, double value, DateTime date, Guid categoryId, Guid userId)
        {
            Title = title.ToUpper();
            Value = value;
            Date = date;
            CategoryId = categoryId;
            UserId = userId;
        }
    }
}
