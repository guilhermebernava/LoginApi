using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class UserCategoryConfiguration : IEntityTypeConfiguration<UserCategory>
    {
        public void Configure(EntityTypeBuilder<UserCategory> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Deleted).IsRequired();
            builder.Property(t => t.UserId).IsRequired();
            builder.Property(t => t.CategoryId).IsRequired();

            builder.HasOne(_ => _.User).WithMany(_ => _.UserCategories).HasForeignKey(_ => _.UserId);
            builder.HasOne(_ => _.Category).WithMany(_ => _.UserCategories).HasForeignKey(_ => _.CategoryId);
        }
    }
}
