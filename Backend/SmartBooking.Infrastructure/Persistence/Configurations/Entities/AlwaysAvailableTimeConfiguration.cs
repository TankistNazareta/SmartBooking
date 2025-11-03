using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBooking.Domain.Entities;

namespace SmartBooking.Infrastructure.Persistence.Configurations.Entities
{
    public class AlwaysAvailableTimeConfiguration : IEntityTypeConfiguration<AlwaysAvailableTime>
    {
        public void Configure(EntityTypeBuilder<AlwaysAvailableTime> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.AlwaysAvailableTimeEnum)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(a => a.RentElementId)
                .IsRequired();

            builder.HasIndex(a => a.RentElementId);
        }
    }
}
