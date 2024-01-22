using JoyTop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoyTop.Infrastructure.Data.Configurations
{
    internal class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.UserId).IsUnique(false);

            builder.Property(x => x.Latitude).IsRequired();
            
            builder.Property(x => x.Longitude).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Locations)
                .HasForeignKey(x => x.UserId);
        }
    }
}
