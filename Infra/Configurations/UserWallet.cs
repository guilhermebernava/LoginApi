using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class UserWalletConfiguration : IEntityTypeConfiguration<UserWallet>
    {
        public void Configure(EntityTypeBuilder<UserWallet> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Deleted).IsRequired();
            builder.Property(t => t.MonthlyExpanse).IsRequired();
            builder.Property(t => t.MonthlyEarning).IsRequired();

            builder.HasOne(_ => _.User).WithOne(_ => _.UserWallet).HasForeignKey<UserWallet>(_=> _.UserId);
        }
    }
}
