using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.UserWalletQuery
{
    public class UserWalletGetByUserIdQueryHandler : IRequestHandler<UserWalletGetByUserIdQuery, ResponseDto>
    {
        private IUserWalletRepository _userWalletRepository;

        public UserWalletGetByUserIdQueryHandler(IUserWalletRepository userWalletRepository)
        {
            _userWalletRepository = userWalletRepository;
        }

        public async Task<ResponseDto> Handle(UserWalletGetByUserIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _userWalletRepository.GetByUserIdAsync(request.UserId);
            return new ResponseDto(list);
        }
    }
}
