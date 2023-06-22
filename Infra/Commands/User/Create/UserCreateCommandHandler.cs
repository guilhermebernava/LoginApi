using Domain.Entities;
using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, ResponseDto>
    {
        private IUserRepository _userRepository;

        public UserCreateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = new AppUser(request.Email, request.Password, request.TwoFactor,request.UserName);
            await _userRepository.AddAsync(entity);
            return new ResponseDto();
        }
    }
}
