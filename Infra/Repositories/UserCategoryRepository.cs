using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserCategoryRepository : Repository<UserCategory>, IUserCategoryRepository
    {
        public UserCategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserCategory>> GetAllByUserIdAsync(Guid userId)
        {
            try
            {
                var userCategories = await _dbSet.Where(_ => _.UserId == userId).ToListAsync();
                return userCategories;
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }
    }
}
