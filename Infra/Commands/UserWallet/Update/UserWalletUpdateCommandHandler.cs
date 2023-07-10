using Domain.Repositories;
using Infra.Exceptions;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.UserWalletCommand
{
    public class UserWalletUpdateCommandHandler : IRequestHandler<UserWalletUpdateCommand, ResponseDto>
    {
        private IUserWalletRepository _userWalletRepository;

        public UserWalletUpdateCommandHandler(IUserWalletRepository userWalletRepository)
        {
            _userWalletRepository = userWalletRepository;
        }

        public async Task<ResponseDto> Handle(UserWalletUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userWalletRepository.GetByUserIdAsync(request.UserId);

            if (entity == null)
            {
                throw new NotFoundException($"Not found any USER WALLET {request.UserId}");
            }

            entity.MonthlyEarning = request.MonthlyEarning;
            entity.MonthlyExpanse = request.MonthlyExpanses;

            await _userWalletRepository.UpdateAsync(entity);
            return new ResponseDto();
        }
    }
}
