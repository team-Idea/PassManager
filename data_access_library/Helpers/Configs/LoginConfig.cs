using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System;
using static data_access_library.Helpers.Configs.EncryptionDB;

namespace data_access_library.Helpers.Config
{
    internal class LoginConfig : IEntityTypeConfiguration<Login_Item>
    {
        public void Configure(EntityTypeBuilder<Login_Item> builder)
        {
            builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
            builder.Property(l => l.IsFavourite).HasDefaultValue(false);
            builder.HasOne(l => l.User).WithMany(u => u.Logins).HasForeignKey(l => l.UserId);
            builder.Property(l => l.SavedLogin).IsRequired().HasMaxLength(200).HasConversion(val => Encrypt(val),
            val => Decrypt(val)); 
            builder.Property(l => l.SavedPassword).IsRequired().HasMaxLength(200).HasConversion(val => Encrypt(val),
            val => Decrypt(val));

        }
        
    }
}
