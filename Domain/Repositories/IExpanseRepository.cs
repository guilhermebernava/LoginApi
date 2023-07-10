using Domain.DTOs;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IExpanseRepository : IRepository<Expanse>
    {
        public Task<List<Expanse>> GetByMonthAsync(DateTime date, Guid userId);
        public Task<List<Expanse>> GetByCategoryIdAsync(Guid categoryId, Guid userId);
        public Task<List<Expanse>> GetAllByUserIdAsync(Guid userId);
    }
}
