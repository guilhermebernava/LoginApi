using Infra.Mediator.Classes;

namespace Infra.Commands.ExpanseQuery
{
    public class ExpanseGenerateMonthSummaryQuery : Request
    {
        public Guid UserId { get; set; }
    }
}
