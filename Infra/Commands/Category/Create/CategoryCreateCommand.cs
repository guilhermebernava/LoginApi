using Infra.Mediator.Classes;

namespace Infra.Commands.CategoryCommands
{
    public class CategoryCreateCommand : Request
    {
        public CategoryCreateCommand(string name, bool isCore)
        {

            Name = name;
            IsCore = isCore;
        }

        public string Name { get; private set; }
        public bool IsCore { get; private set; }

    }
}
