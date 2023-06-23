using Domain.Entities;
using Domain.Redis;
using Infra.Exceptions;
using Infra.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Infra.Redis
{
    public class RedisRepository<T> : IRedisRepository<T> where T : Entity
    {
        private IDistributedCache _cache;

        public RedisRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<bool> Add(string key, T entity)
        {
            try
            {
                await _cache.SetRecordAsync(key, entity);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> GetByKey(string key)
        {
            try
            {
                var result = await _cache.GetRecordAsync<T>(key);

                if (result == null)
                {
                    throw new NotFoundException("Not found");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
