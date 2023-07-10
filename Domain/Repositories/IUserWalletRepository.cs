using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserWalletRepository : IRepository<UserWallet>
    {
        Task<UserWallet> GetByUserIdAsync(Guid userId);
    }
}
