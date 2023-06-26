using Domain.Redis;
using Infra.Mediator.Classes;
using MediatR;

namespace Infra.Commands.User
{
    public class UserTwoFactorQueryHandler : IRequestHandler<UserTwoFactorQuery, ResponseDto>
    {
        private ITwoFactorRedisRepository _twoFactorRedisRepository;

        public UserTwoFactorQueryHandler(ITwoFactorRedisRepository twoFactorRedisRepository)
        {
            _twoFactorRedisRepository = twoFactorRedisRepository;
        }

        public async Task<ResponseDto> Handle(UserTwoFactorQuery request, CancellationToken cancellationToken)
        {
            var token = await _twoFactorRedisRepository.ValidateCode(request.Code);
            return new ResponseDto(token);
        }
    }
}
