using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBooking.Domain.Agregates;

namespace SmartBooking.Infrastructure.Persistence.Configurations.Aggregates
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.PasswordHash)
                .HasMaxLength(255);

            builder.Property(u => u.Provider)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(u => u.Role)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(u => u.JoinTime)
                .IsRequired();

            builder.HasMany(u => u.RefreshTokens)
                .WithOne()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
