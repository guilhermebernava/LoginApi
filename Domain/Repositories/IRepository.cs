using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        public Task AddAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid Id);
        public Task UpdateAsync(T entity);
        public Task DeleteByIdAsync(Guid Id);
        public Task<bool> SaveAsync();
    }
}
