namespace Domain.Redis
{
    public interface IRedisRepository<T>
    {
        public Task<T> GetByKey(string id);
        public Task<bool> Add(string key,T entity);
    }
}
