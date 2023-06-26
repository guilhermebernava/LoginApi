using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserGetByEmailQuery : Request
    {
        public UserGetByEmailQuery(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
