using Domain.Entities;

namespace Domain.Redis
{
    public interface ITwoFactorRedisRepository : IRedisRepository<AppUserTwoFactor>
    {
    }
}
