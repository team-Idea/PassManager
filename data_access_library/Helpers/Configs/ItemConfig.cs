using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers.Config
{
    internal class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(i => i.Name).IsRequired().HasMaxLength(100);
            builder.Property(i => i.SavedLogin).IsRequired().HasMaxLength(100);
            builder.Property(i => i.SavedPass).IsRequired().HasMaxLength(100);
            builder.Property(i => i.Category).IsRequired().HasMaxLength(100);
            builder.Property(i => i.IsFavourite).HasDefaultValue(false);
            builder.HasOne(i => i.Category).WithMany(c => c.Items).HasForeignKey(i => i.CategoryId);
            builder.HasOne(i => i.User).WithMany(u => u.Items).HasForeignKey(i => i.UserId);
        }
    }
}