using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Task<bool> ExistCategoryByNameAsync(string categoryName);
        public Task<List<Category>> GetAllByUserCategoriesAsync(List<UserCategory> userCategories);
        public Task<List<Category>> GetAllCoreCategoriesAsync();
    }
}
