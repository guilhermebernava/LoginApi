using Infra.Mediator.Classes;

namespace Infra.Commands.User
{
    public class UserTwoFactorQuery : Request
    {
        public UserTwoFactorQuery(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
