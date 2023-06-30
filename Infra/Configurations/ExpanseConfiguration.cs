using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Configurations
{
    public class ExpanseConfiguration : IEntityTypeConfiguration<Expanse>
    {
        public void Configure(EntityTypeBuilder<Expanse> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Deleted).IsRequired();
            builder.Property(t => t.UserId).IsRequired();
            builder.Property(t => t.CategoryId).IsRequired();
            builder.Property(t => t.Title).IsRequired();
            builder.Property(t => t.Value).IsRequired();
            builder.Property(t => t.Date).IsRequired();

            builder.HasOne(_ => _.User).WithMany(_ => _.Expanses).HasForeignKey(_ => _.UserId);
            builder.HasOne(_ => _.Category).WithMany(_ => _.Expanses).HasForeignKey(_ => _.CategoryId);
        }
    }
}
