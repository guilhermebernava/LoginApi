using Infra.Exceptions;
using Infra.Mediator.Classes;
using Infra.Utils;

namespace Infra.Commands.User
{
    public class UserPasswordUpdateCommand : Request
    {
        public UserPasswordUpdateCommand(string newPassword, string email)
        {
            if (!PasswordUtils.IsValidPassword(newPassword))
            {
                throw new UtilsException("Password is not strong, it has to be with at least 1 lower char, 1 upper char, 1 special char and 8 digits");
            }
            NewPassword = newPassword;
            Email = email;
        }

        public string NewPassword { get; init; }
        public string Email { get; set; }
    }
}
