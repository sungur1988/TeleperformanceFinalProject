using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ShoppingListConfigurations : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.HasIndex(x => x.Name).IsUnique();

        }
    }
}
