using Domain.Entities;
using Domain.Redis;
using Infra.Exceptions;
using Infra.Utils;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using RedisException = Infra.Exceptions.RedisException;

namespace Infra.Redis
{
    public class TwoFactorRedisRepository : RedisRepository<AppUserTwoFactor>, ITwoFactorRedisRepository
    {

        private readonly IConfiguration _configuration;
        public TwoFactorRedisRepository(IDistributedCache cache, IConnectionMultiplexer redis, IConfiguration configuration) : base(cache,redis)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateCode(AppUser user)
        {
            try
            {
                var code = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                await Add(code, new AppUserTwoFactor(user, code));
                return code;
            }
            catch (Exception ex)
            {
                throw new RedisException(ex.Message);
            }
        }

        public async Task<string> ValidateCode(string code)
        {
            try
            {
                var result = await GetByKey(code);

                if (result == null)
                {
                    throw new NotFoundException("Not found anything with this code");
                }

                return JwtUtils.GenerateToken(_configuration,result.User);
            }
            catch (Exception ex)
            {
                throw new RedisException(ex.Message);
            }
        }
    }
}
