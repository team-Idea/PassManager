﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers.Config
{
    internal class InfoConfig : IEntityTypeConfiguration<Personal_Info>
    {
        public void Configure(EntityTypeBuilder<Personal_Info> builder)
        {
            //public string Name { get; set; }
            //public bool IsFavourite { get; set; }
            //public int CategoryId { get; set; }
            //public Category Category { get; set; }
            //public int UserId { get; set; }
            //public User User { get; set; }
            //public string FirstName { get; set; }
            //public string LastName { get; set; }
            //public string FathersName { get; set; }
            //public string UserName { get; set; }
            //public string Company { get; set; }
            //public string Email { get; set; }
            //public string PhoneNumber { get; set; }
            //public string Country { get; set; }

            builder.Property(pi => pi.Name).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.IsFavourite).HasDefaultValue(false);
            builder.HasOne(pi => pi.Category).WithMany(c => c.Infos).HasForeignKey(pi => pi.CategoryId);
            builder.HasOne(pi => pi.User).WithMany(u => u.Infos).HasForeignKey(pi => pi.UserId);
            builder.Property(pi => pi.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.LastName).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.FathersName).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.UserName).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.Email).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.Company).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.PhoneNumber).IsRequired().HasMaxLength(100);
            builder.Property(pi => pi.Country).IsRequired().HasMaxLength(100);
        }
    }
}
