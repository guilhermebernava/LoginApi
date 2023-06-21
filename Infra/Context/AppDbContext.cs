using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppUserTwoFactor> UserTwoFactors { get; set; }
    }
}
