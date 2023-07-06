using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> ExistCategoryByName(string categoryName)
        {
            try
            {
                var exist = await _dbSet.FirstOrDefaultAsync(_ => _.Name == categoryName.ToUpper());
                return exist != null;
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }

        public async Task<List<Category>> GetAllByUserCategories(List<UserCategory> userCategories)
        {
            try
            {
                var categories = new List<Category>();
                await Task.Run(() =>
                 Parallel.ForEach(userCategories, async userCategory =>
                {
                    var category = await _dbSet.FirstOrDefaultAsync(_ => _.Id == userCategory.CategoryId);

                    if (category == null)
                    {
                        throw new DbException($"Could not find an category with this ID - {userCategory.CategoryId}");
                    }

                    categories.Add(category);
                })
                );

                return categories;
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }

        public async Task<List<Category>> GetAllCoreCategories()
        {
            try
            {
                var list = await _dbSet.Where(_ => _.IsCore == true).ToListAsync();
                return list;
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }
    }
}
