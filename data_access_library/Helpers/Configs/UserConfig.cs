using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using static data_access_library.Helpers.Configs.EncryptionDB;

namespace data_access_library.Helpers.Config
{
    internal class UserConfig : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder.Property(u => u.Login).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(200).HasConversion(val =>  Encrypt(val),
            val => Decrypt(val));
        }

    }
}

