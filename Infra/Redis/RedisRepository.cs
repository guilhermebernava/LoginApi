using Domain.Entities;
using Domain.Redis;
using Infra.Exceptions;
using Infra.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using RedisException = Infra.Exceptions.RedisException;

namespace Infra.Redis
{
    public class RedisRepository<T> : IRedisRepository<T> where T : Entity
    {
        private  IDistributedCache _cache;
        private readonly IConnectionMultiplexer _redis;

        public RedisRepository(IDistributedCache cache, IConnectionMultiplexer redis)
        {
            _cache = cache;
            _redis = redis;
        }

        public async Task<bool> Add(string key, T entity)
        {
            try
            {
                if (!IsOnline())
                {
                    throw new RedisException("REDIS IS OFFLINE");
                }

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
                if (!IsOnline())
                {
                    throw new RedisException("REDIS IS OFFLINE");
                }

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

        private bool IsOnline()
        {
            try
            {
                return _redis.IsConnected;

            }
            catch (Exception ex) {
                throw new RedisException(ex.Message);
            }
        }
    }
}
