using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBooking.Domain.Aggregates;

namespace SmartBooking.Infrastructure.Persistence.Configurations.Aggregates
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Price)
                .IsRequired();

            builder.Property(r => r.Status)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(r => r.CreatedAt)
                .IsRequired();

            builder.Property(r => r.RentAt)
                .IsRequired();

            builder.HasIndex(r => new { r.UserId, r.AlwaysAvailableTimeId });

            builder.HasOne<Domain.Entities.AlwaysAvailableTime>()
                .WithMany()
                .HasForeignKey(r => r.AlwaysAvailableTimeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
