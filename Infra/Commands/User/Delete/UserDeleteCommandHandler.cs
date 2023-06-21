using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand, ResponseDto>
    {
        private IUserRepository _userRepository;

        public UserDeleteCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteByIdAsync(request.Id);
            return new ResponseDto();
        }
    }
}
