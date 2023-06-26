using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserCreateCommand : Request
    {
        public UserCreateCommand(string? userName, bool twoFactor, string password, string email)
        {
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
