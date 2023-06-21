using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserGetByEmailQuery : Request
    {
        public string Email { get; set; }
    }
}
