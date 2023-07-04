using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserCategoriesCommand : Request
    {
        public UserCategoriesCommand(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}
