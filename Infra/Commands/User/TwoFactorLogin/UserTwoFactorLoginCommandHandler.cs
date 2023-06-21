using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserTwoFactorLoginCommandHandler : IRequestHandler<UserTwoFactorLoginCommand, ResponseDto>
    {
        private IUserRepository _userRepository;

        public UserTwoFactorLoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto> Handle(UserTwoFactorLoginCommand request, CancellationToken cancellationToken)
        {
            //TODO implementar
            return new ResponseDto();
        }
    }
}
