using Infra.Exceptions;
using Infra.Mediator.Classes;

namespace Infra.Commands.ExpanseCommands
{
    public class ExpanseCreateCommand : Request
    {
        public ExpanseCreateCommand(string title, double value, DateTime date, Guid categoryId, Guid userId)
        {
            if(value <= 0)
            {
                throw new UtilsException("Value must be greater than 0");
            }

            Title = title;
            Value = value;
            Date = date;
            CategoryId = categoryId;
            UserId = userId;
        }

        public string Title { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

    }
}
