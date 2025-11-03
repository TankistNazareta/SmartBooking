using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBooking.Domain.Entities;

namespace SmartBooking.Infrastructure.Persistence.Configurations.Entities
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Code)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.IsActive)
                .IsRequired();

            builder.Property(c => c.ExpireAt)
                .IsRequired();

            builder.HasIndex(c => c.Code)
                .IsUnique();

            builder.HasOne<Domain.Aggregates.Rent>()
                .WithMany()
                .HasForeignKey(c => c.RentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
