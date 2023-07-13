using Infra.Mediator.Classes;

namespace Infra.Commands.UserCategoryCommand
{
    public class UserCategoryCreateCommand : Request
    {
        public UserCategoryCreateCommand(Guid userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public string Name { get; set; }
        public Guid UserId { get; private set; }
    }
}
