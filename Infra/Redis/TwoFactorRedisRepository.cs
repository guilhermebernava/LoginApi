using Domain.Entities;
using Domain.Redis;
using Microsoft.Extensions.Caching.Distributed;

namespace Infra.Redis
{
    public class TwoFactorRedisRepository : RedisRepository<AppUserTwoFactor>, ITwoFactorRedisRepository
    {
        public TwoFactorRedisRepository(IDistributedCache cache) : base(cache)
        {
        }
    }
}
