using Domain.Redis;
using Domain.Repositories;
using Infra.Mediator.Classes;
using Infra.Utils;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Infra.Commands.User
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ResponseDto>
    {
        private readonly IConfiguration _configuration;
        private IUserRepository _userRepository;
        private readonly ITwoFactorRedisRepository _twoFactorRedisRepository;

        public UserLoginCommandHandler(IUserRepository userRepository, IConfiguration configuration, ITwoFactorRedisRepository twoFactorRedisRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _twoFactorRedisRepository = twoFactorRedisRepository;
        }

        public async Task<ResponseDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var dto = await _userRepository.LoginAsync(request.Email, request.Password);

            if (dto == null)
            {
                return new ResponseDto(false);
            }

            if (dto.Code)
            {
                var code = await _twoFactorRedisRepository.GenerateCode(dto.User);
                SendEmailUtils.SendEmail(request.Email,code,_configuration);
                return new ResponseDto("Email sent with success, check your email");
            }
            return new ResponseDto(dto.Token);
        }
    }
}
