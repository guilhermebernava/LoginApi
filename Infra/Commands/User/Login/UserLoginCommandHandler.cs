using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ResponseDto>
    {
        private IUserRepository _userRepository;

        public UserLoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var token = await _userRepository.LoginAsync(request.Email, request.Password);
            return new ResponseDto(token);
        }
    }
}
