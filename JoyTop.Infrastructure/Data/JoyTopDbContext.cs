using JoyTop.Domain.Entities;
using JoyTop.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JoyTop.Infrastructure.Data
{
    public class JoyTopDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new LocationConfiguration());
        }
    }
}
