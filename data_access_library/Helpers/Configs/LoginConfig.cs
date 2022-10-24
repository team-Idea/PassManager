using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers.Config
{
    internal class LoginConfig : IEntityTypeConfiguration<Login_Item>
    {
        public void Configure(EntityTypeBuilder<Login_Item> builder)
        {
            //public string Name { get; set; }
            //public bool IsFavourite { get; set; }
            //public int CategoryId { get; set; }
            //public Category Category { get; set; }
            //public int UserId { get; set; }
            //public User User { get; set; }
            //public string SavedLogin { get; set; }
            //public string SavedPassword { get; set; }

            builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
            builder.Property(l => l.IsFavourite).HasDefaultValue(false);
            builder.HasOne(l => l.Category).WithMany(c => c.Logins).HasForeignKey(l => l.CategoryId);
            builder.HasOne(l => l.User).WithMany(u => u.Logins).HasForeignKey(l => l.UserId);
            builder.Property(l => l.SavedLogin).IsRequired().HasMaxLength(100);
            builder.Property(l => l.SavedPassword).IsRequired().HasMaxLength(100);
        }
    }
}
