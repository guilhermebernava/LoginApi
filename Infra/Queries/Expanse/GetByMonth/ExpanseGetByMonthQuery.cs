using Infra.Mediator.Classes;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGetByMonthQuery : Request
    {
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
