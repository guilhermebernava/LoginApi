using Infra.Mediator.Classes;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGetByCategoryIdQuery : Request
    {

        public Guid CategoryId { get; private set; }
        public Guid UserId { get; private set; }
    }
}
