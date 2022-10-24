using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers.Config
{
    internal class InfoConfig : IEntityTypeConfiguration<Personal_Info>
    {
        public void Configure(EntityTypeBuilder<Personal_Info> builder)
        {
            builder.Property(pi => pi.Name).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.IsFavourite).HasDefaultValue(false);
            builder.Property(pi => pi.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.LastName).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.FathersName).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.UserName).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.Email).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.Company).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.PhoneNumber).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.Country).IsRequired().HasMaxLength(100);
            builder.HasOne(pi => pi.User).WithMany(u => u.Infos).HasForeignKey(pi => pi.UserId);
        }
    }
}
