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

            if(entity == null)
            {
                throw new RepositoryException($"Not found this User - {request.Id}");
            }

            entity.Email = request.Email;
            entity.Name = request.Username;

            await _userRepository.UpdateAsync(entity);
            return new ResponseDto();
        }
    }
}
