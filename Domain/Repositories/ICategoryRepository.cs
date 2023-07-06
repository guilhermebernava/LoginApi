using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Task<bool> ExistCategoryByName(string categoryName);
        public Task<List<Category>> GetAllByUserCategories(List<UserCategory> userCategories);
        public Task<List<Category>> GetAllCoreCategories();
    }
}
