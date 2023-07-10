using Domain.Entities;
using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.UserWalletCommand
{
    public class UserWalletCreateCommandHandler : IRequestHandler<UserWalletCreateCommand, ResponseDto>
    {
        private IUserWalletRepository _userWalletRepository;

        public UserWalletCreateCommandHandler(IUserWalletRepository userWalletRepository)
        {
            _userWalletRepository = userWalletRepository;
        }

        public async Task<ResponseDto> Handle(UserWalletCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new UserWallet(request.MonthlyEarning,request.MonthlyExpanses,request.UserId);
            await _userWalletRepository.AddAsync(entity);
            return new ResponseDto();
        }
    }
}
