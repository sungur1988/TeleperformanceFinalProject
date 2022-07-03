using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ShoppingListItemConfigurations : IEntityTypeConfiguration<ShoppingListItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingListItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Amount).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();

        }
    }
}
