using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserWalletRepository : Repository<UserWallet>, IUserWalletRepository
    {
        public UserWalletRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserWallet> GetByUserIdAsync(Guid userId)
        {
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(_ => _.UserId == userId);
                if (entity == null)
                {
                    throw new NotFoundException($"Not found any USER WALLET with this USER ID {userId}");
                }

                return entity;
            }
            catch (Exception e)
            {
                throw new DbException(e.Message);
            }
        }
    }
}
