using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserCategoryRepository : IRepository<UserCategory>
    {
        public Task<List<UserCategory>> GetAllByUserIdAsync(Guid userId);
    }
}
