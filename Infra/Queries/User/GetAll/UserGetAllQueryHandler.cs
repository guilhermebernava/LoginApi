using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, ResponseDto>
    {
        private IUserRepository _userRepository;

        public UserGetAllQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseDto> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var list = await _userRepository.GetAllAsync();
            return new ResponseDto(list);
        }
    }
}
