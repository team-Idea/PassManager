using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;
using System;

namespace data_access_library.Helpers.Config
{
    internal class CardConfig : IEntityTypeConfiguration<Credit_Card>
    {
        public void Configure(EntityTypeBuilder<Credit_Card> builder)
        {
            //public string Name { get; set; }
            //public bool IsFavourite { get; set; }
            //public int CategoryId { get; set; }
            //public Category Category { get; set; }
            //public int UserId { get; set; }
            //public User User { get; set; }
            //public string CardHolder { get; set; }
            //public string CardNumber { get; set; }
            //public int CartTypeId { get; set; }
            //public CardType CardType { get; set; }
            //public DateTime DateExpired { get; set; }
            //public int SVV { get; set; }

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.IsFavourite).HasDefaultValue(false);
            builder.HasOne(c => c.Category).WithMany(ct => ct.Cards).HasForeignKey(c => c.CategoryId);
            builder.HasOne(c => c.User).WithMany(u => u.Cards).HasForeignKey(c => c.UserId);
            builder.Property(c => c.CardHolder).IsRequired().HasMaxLength(100);
            builder.Property(c => c.CardNumber).IsRequired().HasMaxLength(100);
            builder.HasOne(c => c.CardType).WithMany(ct => ct.Cards).HasForeignKey(c => c.CartTypeId);
            builder.Property(c => c.DateExpired).HasDefaultValue(DateTime.Now);
            builder.Property(c => c.CVV).IsRequired().HasMaxLength(100);
        }
    }
}
