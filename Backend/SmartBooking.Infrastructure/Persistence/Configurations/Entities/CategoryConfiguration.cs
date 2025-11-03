using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBooking.Domain.Entities;

namespace SmartBooking.Infrastructure.Persistence.Configurations.Entities
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}
