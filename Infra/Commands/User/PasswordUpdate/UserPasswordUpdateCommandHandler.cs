using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserPasswordUpdateCommandHandler : IRequestHandler<UserPasswordUpdateCommand, ResponseDto>
    {
        private IUserRepository _userRepository;

        public UserPasswordUpdateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto> Handle(UserPasswordUpdateCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.UpdatePasswordAsync(request.NewPassword, request.Email);
            return new ResponseDto();
        }
    }
}
