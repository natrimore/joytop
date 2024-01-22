using JoyTop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoyTop.Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.TelegramId).IsUnique();

            builder.Property(x => x.TelegramId).IsRequired();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(60);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(60);

            builder.Property(x => x.Language).IsRequired().HasMaxLength(3);

            builder.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(20);

            builder.Property(x => x.Role).IsRequired();
        }
    }
}
