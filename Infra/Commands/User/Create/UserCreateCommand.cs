using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserCreateCommand : Request
    {
        public string? UserName { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }
    }
}
