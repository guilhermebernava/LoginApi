using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserCategoryRepository : IRepository<UserCategory>
    {
        public Task<List<UserCategory>> GetAllByUserId(Guid userId);
    }
}
