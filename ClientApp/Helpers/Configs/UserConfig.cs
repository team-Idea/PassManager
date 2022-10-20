﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static ClientApp.PasswordManagerDbContext;

namespace ClientApp.Helpers.Config
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Login).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
            builder.HasMany(u => u.Items).WithOne(i => i.User).HasForeignKey(i => i.UserId);
        }
    }
}

