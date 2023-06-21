namespace Domain.Entities
{
    public class AppUserTwoFactor : Entity
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }

        public AppUserTwoFactor(Guid userId, string code)
        {
            UserId = userId;
            Code = code;
        }
    }
}
