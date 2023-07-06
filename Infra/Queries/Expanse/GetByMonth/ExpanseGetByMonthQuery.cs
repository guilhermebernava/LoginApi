using Infra.Mediator.Classes;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGetByMonthQuery : Request
    {
        public ExpanseGetByMonthQuery(DateTime date, Guid userId)
        {
            Date = date;
            UserId = userId;
        }

        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
