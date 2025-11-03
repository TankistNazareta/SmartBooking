using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBooking.Domain.Entities;

namespace SmartBooking.Infrastructure.Persistence.Configurations.Entities
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Token)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(r => r.ExpiresAt)
                .IsRequired();

            builder.Property(r => r.IsRevoked)
                .IsRequired();

            builder.HasIndex(r => r.Token)
                .IsUnique();

            builder.HasOne<Domain.Agregates.User>()
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
