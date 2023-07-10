using Infra.Exceptions;
using Infra.Mediator.Classes;
using Infra.Utils;

namespace Infra.Commands.User
{
    public class UserCreateCommand : Request
    {
        public UserCreateCommand(string? userName, bool twoFactor, string password, string email, double monthlyEarning, double monthlyExpanses)
        {
            if (!PasswordUtils.IsValidPassword(password))
            {
                throw new UtilsException("Password is not strong, it has to be with at least 1 lower char, 1 upper char, 1 special char and 8 digits");
            }

            if (monthlyEarning < 0 || monthlyExpanses < 0)
            {
                throw new BadRequestException("Montlhy Earning or Monthly Expanses must to be greater than 0");
            }

            UserName = userName;
            TwoFactor = twoFactor;
            Password = password;
            Email = email;
            MonthlyEarning = monthlyEarning;
            MonthlyExpanses = monthlyExpanses;
        }

        public string? UserName { get; set; }
        public bool TwoFactor { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public double MonthlyEarning { get; private set; }
        public double MonthlyExpanses { get; private set; }
    }
}
