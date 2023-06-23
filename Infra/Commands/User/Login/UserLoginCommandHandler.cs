using Domain.Repositories;
using Infra.Mediator.Classes;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Infra.Commands.User
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ResponseDto>
    {
        private readonly IConfiguration _configuration;
        private IUserRepository _userRepository;

        public UserLoginCommandHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<ResponseDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var dto = await _userRepository.LoginAsync(request.Email, request.Password);

            if (dto == null)
            {
                return new ResponseDto(false);
            }



            if (dto.Code != null)
            {
                return new ResponseDto(_configuration["URLTwoFactor"] + "?code=" + dto.Code);
            }
            return new ResponseDto(dto.Token ?? "TOKEN IS NULL");
        }
    }
}
