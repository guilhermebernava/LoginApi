using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserTwoFactorQueryHandler : IRequestHandler<UserTwoFactorQuery, ResponseDto>
    {
        private IUserRepository _userRepository;

        public UserTwoFactorQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto> Handle(UserTwoFactorQuery request, CancellationToken cancellationToken)
        {
            var list = await _userRepository.TwoFactorAsync(request.Code);
            return new ResponseDto(list);
        }
    }
}
