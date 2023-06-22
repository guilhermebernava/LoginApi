using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserCreateCommand : Request
    {
        public string? UserName { get; set; }
        public bool TwoFactor { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
