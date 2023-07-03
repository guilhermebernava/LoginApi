using Infra.Exceptions;
using Infra.Mediator.Classes;

namespace Infra.Commands.ExpanseCommands
{
    public class ExpanseUpdateCommand : Request
    {
        public ExpanseUpdateCommand(string title, double value, DateTime date, Guid categoryId, Guid userId, Guid id)
        {
            if (value <= 0)
            {
                throw new UtilsException("Value must be greater than 0");
            }

            Title = title;
            Value = value;
            Date = date;
            CategoryId = categoryId;
            UserId = userId;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

    }
}
