using Infra.Exceptions;
using Infra.Mediator.Classes;
using Infra.Utils;

namespace Infra.Commands.User
{
    public class UserCreateCommand : Request
    {
        public UserCreateCommand(string? userName, bool twoFactor, string password, string email)
        {
             if (!PasswordUtils.IsValidPassword(password))
            {
                throw new UtilsException("Password is not strong, it has to be with at least 1 lower char, 1 upper char, 1 special char and 8 digits");
            }
            UserName = userName;
            TwoFactor = twoFactor;
            Password = password;
            Email = email;
        }

        public string? UserName { get; set; }
        public bool TwoFactor { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
