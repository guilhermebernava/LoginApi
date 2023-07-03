using Infra.Mediator.Classes;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGetByUserId : Request
    {
        public ExpanseGetByUserId(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
