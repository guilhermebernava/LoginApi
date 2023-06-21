using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserLoginCommand : Request
    {
        public string Password { get; init; }
        public string Email { get; init; }
    }
}
