using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class UserWallet : Entity
    {
        public UserWallet(double monthlyEarning, double monthlyExpanse, Guid userId)
        {
            MonthlyEarning = monthlyEarning;
            MonthlyExpanse = monthlyExpanse;
            UserId = userId;
        }

        public double MonthlyEarning { get;  set; }
        public double MonthlyExpanse { get;  set; }
        public Guid UserId { get; private set; }

        [JsonIgnore]
        public virtual AppUser User { get; set; }
    }
}
