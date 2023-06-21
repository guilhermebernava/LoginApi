using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class AppUserTwoFactorConfiguration : IEntityTypeConfiguration<AppUserTwoFactor>
    {
        public void Configure(EntityTypeBuilder<AppUserTwoFactor> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Deleted).IsRequired();
            builder.Property(t => t.Code).IsRequired();
            builder.Property(t => t.UserId).IsRequired();
        }
    }
}
