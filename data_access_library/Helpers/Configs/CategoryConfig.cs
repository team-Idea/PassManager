using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers.Config
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(c => c.Logins).WithOne(l => l.Category).HasForeignKey(l => l.CategoryId);
            builder.HasMany(c => c.Cards).WithOne(c => c.Category).HasForeignKey(c => c.CategoryId);
            builder.HasMany(c => c.Infos).WithOne(pi => pi.Category).HasForeignKey(pi => pi.CategoryId);
        }
    }
}