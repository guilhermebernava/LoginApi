using Infra.Mediator.Classes;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGetByUserIdQuery : Request
    {

        public Guid UserId { get; set; }
    }
}
