using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserUpdateCommand : Request
    {
        public Guid Id { get; init; }
        public string Email { get; init; }
        public string Username { get; init; }
    }
}
