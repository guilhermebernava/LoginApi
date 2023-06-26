using Domain.DTOs;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepository<AppUser>
    {
        public Task<AppUser> GetByEmailAsync(string email);
        public Task<LoginDto> LoginAsync(string email,string password);
    }
}
