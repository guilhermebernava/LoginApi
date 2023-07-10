using Infra.Mediator.Classes;

namespace Infra.Commands.UserWalletCommand
{
    public class UserWalletUpdateCommand : Request
    {
        public UserWalletUpdateCommand(Guid userId, double monthlyEarning, double monthlyExpanses)
        {
            UserId = userId;
            MonthlyEarning = monthlyEarning;
            MonthlyExpanses = monthlyExpanses;
        }

        public Guid UserId { get; private set; }
        public double MonthlyEarning { get; private set; }
        public double MonthlyExpanses { get; private set; }
    }
}
