using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers.Config
{
    internal class LoginConfig : IEntityTypeConfiguration<Login_Item>
    {
        public void Configure(EntityTypeBuilder<Login_Item> builder)
        {
            builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
            builder.Property(l => l.IsFavourite).HasDefaultValue(false);
            builder.Property(l => l.SavedLogin).IsRequired().HasMaxLength(100);
            builder.Property(l => l.SavedPassword).IsRequired().HasMaxLength(100);
            builder.HasOne(l => l.User).WithMany(u => u.Logins).HasForeignKey(l => l.UserId);
        }
    }
}
