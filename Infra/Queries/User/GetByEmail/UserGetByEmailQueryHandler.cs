using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserGetByEmailQueryHandler : IRequestHandler<UserGetByEmailQuery, ResponseDto>
    {
        private IUserRepository _userRepository;

        public UserGetByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto> Handle(UserGetByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            return new ResponseDto(user);
        }
    }
}
