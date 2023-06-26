using Domain.Entities;

namespace Domain.Redis
{
    public interface ITwoFactorRedisRepository : IRedisRepository<AppUserTwoFactor>
    {
        public Task<string> ValidateCode(string code);
        public Task<string> GenerateCode(Guid userId);
    }

}
