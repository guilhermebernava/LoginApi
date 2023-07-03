using Infra.Mediator.Classes;

namespace Infra.Commands.ExpanseCommands
{
    public class ExpanseDeleteCommand : Request
    {
        public ExpanseDeleteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

    }
}
