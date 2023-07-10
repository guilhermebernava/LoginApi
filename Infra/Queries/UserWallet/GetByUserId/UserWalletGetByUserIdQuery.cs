using Infra.Mediator.Classes;

namespace Infra.Commands.UserWalletQuery
{
    public class UserWalletGetByUserIdQuery : Request
    {
        public UserWalletGetByUserIdQuery(Guid userId)
        {
            UserId  = userId;
        }
        public Guid UserId { get; private set; }
    }
}
