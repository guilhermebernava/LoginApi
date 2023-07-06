using Infra.Mediator.Classes;

namespace Infra.Commands.UserCategoryQuery
{
    public class UserCategoryGetByUserIdQuery : Request
    {
        public UserCategoryGetByUserIdQuery(Guid userId)
        {
            UserId  = userId;
        }
        public Guid UserId { get; private set; }
    }
}
