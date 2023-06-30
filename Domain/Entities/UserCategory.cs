namespace Domain.Entities
{
    public class UserCategory : Entity
    {
        public Guid UserId { get; set; }
        public virtual AppUser User { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public UserCategory(Guid userId,Guid categoryId) 
        {
            UserId = userId;
            CategoryId = categoryId;
        }
    }
}
