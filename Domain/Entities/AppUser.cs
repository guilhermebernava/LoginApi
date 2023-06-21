using Infra.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class AppUser : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool TwoFactor { get; set; }

        public AppUser(string email, string password)
        {
            CheckEmail(email);
            Email = email;
            Password = PasswordServices.ConvertPassword(password);
        }

        public AppUser(string email, string password,string? name)
        {
            CheckEmail(email);
            Email = email;
            Name = name ?? "";
            Password = PasswordServices.ConvertPassword(password);
        }

        private void CheckEmail(string email)
        {
            string checkEmail = "[0-9 a-z A-Z]{1-100}@[a-z A-Z 0-9]{2-50}.[a-z A-Z]{1-10}";

            if (!Regex.IsMatch(email, checkEmail))
            {
                throw new ValidationException($"Ïnvalid email \n {email}\n email must be like test@test.com");
            }
        }

    }
}
