using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBooking.Domain.Entities;

namespace SmartBooking.Infrastructure.Persistence.Configurations.Entities
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Rating)
                .IsRequired();

            builder.Property(r => r.Comment)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasIndex(r => new { r.UserId, r.RentElementId })
                .IsUnique();

            builder.HasOne<Domain.Agregates.User>()
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Domain.Agregates.RentElement>()
                .WithMany()
                .HasForeignKey(r => r.RentElementId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
