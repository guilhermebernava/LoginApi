using Infra.Mediator.Classes;

namespace Infra.Commands.CategoryCommands
{
    public class CategoryDeleteCommand : Request
    {
        public CategoryDeleteCommand(Guid id)
        {

            Id = id;
        }

        public Guid Id { get; private set; }

    }
}
