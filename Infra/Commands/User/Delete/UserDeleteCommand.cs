using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserDeleteCommand : Request
    {
        public Guid Id { get; init; }
    }
}
