using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers.Config
{
    internal class CardConfig : IEntityTypeConfiguration<Credit_Card>
    {
        public void Configure(EntityTypeBuilder<Credit_Card> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.CardNumber).IsRequired().HasMaxLength(100);
            builder.Property(c => c.CardHolder).IsRequired().HasMaxLength(100);
            builder.Property(c => c.IsFavourite).HasDefaultValue(false);
            builder.Property(c => c.DateExpired).HasDefaultValue(DateTime.Now);
            builder.HasOne(c => c.CardType).WithMany(ct => ct.Cards).HasForeignKey(c => c.CartTypeId);
            builder.HasOne(c => c.User).WithMany(u => u.Cards).HasForeignKey(c => c.UserId);
        }
    }
}
