using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserDeleteCommand : Request
    {
        public UserDeleteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}
