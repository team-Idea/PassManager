using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static data_access_library.PasswordManagerDbContext;

namespace data_access_library.Helpers.Config
{
    internal class CardTypeConfig : IEntityTypeConfiguration<CardType>
    {
        public void Configure(EntityTypeBuilder<CardType> builder)
        {
            builder.Property(ct => ct.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(ct => ct.Cards).WithOne(c => c.CardType).HasForeignKey(ct => ct.CartTypeId);
        }
    }
}
