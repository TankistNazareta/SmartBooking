using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBooking.Domain.Agregates;

namespace SmartBooking.Infrastructure.Persistence.Configurations.Aggregates
{
    public class RentElementConfiguration : IEntityTypeConfiguration<RentElement>
    {
        public void Configure(EntityTypeBuilder<RentElement> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(r => r.Price)
                .IsRequired();

            builder.Property(r => r.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(r => r.Location)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(r => r.CreatedAt)
                .IsRequired();

            builder.HasMany(r => r.AlwaysAvailableTimes)
                .WithOne()
                .HasForeignKey(a => a.RentElementId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(r => new { r.CategoryId, r.AdminId });
        }
    }
}
