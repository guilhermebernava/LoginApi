using Domain.Repositories;
using Infra.Exceptions;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, ResponseDto>
    {
        private IUserRepository _userRepository;

        public UserUpdateCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.GetByIdAsync(request.Id);

            entity.Email = request.Email;
            entity.TwoFactor = request.TwoFactor;
            entity.Name = request.Username;

            await _userRepository.UpdateAsync(entity);
            return new ResponseDto();
        }
    }
}
