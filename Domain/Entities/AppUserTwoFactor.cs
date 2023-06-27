namespace Domain.Entities
{
    public class AppUserTwoFactor : Entity
    {
        public AppUser User { get; set; }
        public string Code { get; set; }

        public AppUserTwoFactor(AppUser user, string code)
        {
            User = user;
            Code = code;
        }
    }
}
