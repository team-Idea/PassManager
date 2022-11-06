using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers.Config
{
    internal class UserConfig : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder.Property(u => u.Login).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        }
    }
}

