using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserLoginCommand : Request
    {
        public UserLoginCommand(string password, string email)
        {
            Password = password;
            Email = email;
        }

        public string Password { get; init; }
        public string Email { get; init; }
    }
}
