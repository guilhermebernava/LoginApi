using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserTwoFactorLoginCommand : Request
    {
        public string Code { get; init; }
    }
}
