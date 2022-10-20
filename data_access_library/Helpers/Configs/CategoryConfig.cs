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
            builder.HasMany(c => c.Items).WithOne(i => i.Category).HasForeignKey(i => i.CategoryId);
        }
    }
}