using Domain.Entities;
using Domain.Repositories;
using Infra.Context;

namespace Infra.Repositories
{
    public class UserTwoFactorRepository : Repository<AppUserTwoFactor>, IUserTwoFactorRepository
    {
        public UserTwoFactorRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
