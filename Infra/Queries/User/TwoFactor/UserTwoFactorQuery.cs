using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserTwoFactorQuery : Request
    {
        public string Code { get; set; }
    }
}
