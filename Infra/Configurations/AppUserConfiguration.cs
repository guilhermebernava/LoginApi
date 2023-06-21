using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Deleted).IsRequired();
            builder.Property(t => t.Password).IsRequired();
            builder.Property(t => t.TwoFactor).IsRequired();
            builder.Property(t => t.Email).IsRequired();
            builder.Property(t => t.Name);
        }
    }
}
