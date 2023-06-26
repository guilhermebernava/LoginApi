using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserUpdateCommand : Request
    {
        public UserUpdateCommand(Guid id, string email, bool twoFactor, string username)
        {
            Id = id;
            Email = email;
            TwoFactor = twoFactor;
            Username = username;
        }

        public Guid Id { get; init; }
        public string Email { get; init; }
        public bool TwoFactor { get; init; }
        public string Username { get; init; }
    }
}
