using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserPasswordUpdateCommand : Request
    {
        public string NewPassword { get; init; }
        public string Email { get; set; }
    }
}
