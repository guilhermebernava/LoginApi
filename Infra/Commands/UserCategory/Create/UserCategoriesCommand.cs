using Infra.Mediator.Classes;

namespace Infra.Commands.UserCategoryCommand
{
    public class UserCategoryCreateCommand : Request
    {
        public UserCategoryCreateCommand(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}
