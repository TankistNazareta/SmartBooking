using Microsoft.EntityFrameworkCore;
using SmartBooking.Domain.Aggregates;
using SmartBooking.Domain.Agregates;
using SmartBooking.Domain.Entities;
using SmartBooking.Infrastructure.Persistence.Configurations.Aggregates;
using SmartBooking.Infrastructure.Persistence.Configurations.Entities;

namespace SmartBooking.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Rent> Rents { get; set; }
        public DbSet<RentElement> RentElements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<AlwaysAvailableTime> AlwaysAvailableTimes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new RentConfiguration());
            modelBuilder.ApplyConfiguration(new RentElementConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new AlwaysAvailableTimeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CouponConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
