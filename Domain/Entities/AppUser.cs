using Domain.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class AppUser : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; } = "";
        public bool TwoFactor { get; set; }
        [JsonIgnore]
        public virtual ICollection<Expanse> Expanses { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserCategory> UserCategories { get; set; }

        public AppUser(string email, string password, bool twoFactor)
        {
            CheckEmail(email);
            Email = email;
            Password = PasswordServices.EncryptPassword(password);
            TwoFactor = twoFactor;
        }

        [JsonConstructor]
        public AppUser(string email, string password,bool twoFactor,string name)
        {
            CheckEmail(email);
            Email = email;
            TwoFactor = twoFactor;
            Name = name;
            Password = PasswordServices.EncryptPassword(password);
        }

        private void CheckEmail(string email)
        {
            string checkEmail = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";

            if (!Regex.IsMatch(email, checkEmail))
            {
                throw new ValidationException($"Ïnvalid email \n {email}\n email must be like test@test.com");
            }
        }

    }
}
