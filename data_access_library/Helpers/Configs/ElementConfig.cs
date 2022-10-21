using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers.Config
{
    internal class ElementConfig : IEntityTypeConfiguration<Element>
    {
        public void Configure(EntityTypeBuilder<Element> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.IsFavourite).HasDefaultValue(false);
            builder.HasOne(e => e.Category).WithMany(c => c.Elements).HasForeignKey(e => e.CategoryId);
        }
    }
}