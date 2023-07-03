using Infra.Mediator.Classes;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGetByCategoryIdQuery : Request
    {
        public ExpanseGetByCategoryIdQuery(Guid categoryId,Guid userId)
        {
            CategoryId = categoryId;
            UserId = userId;
        }

        public Guid CategoryId { get; private set; }
        public Guid UserId { get; private set; }
    }
}
