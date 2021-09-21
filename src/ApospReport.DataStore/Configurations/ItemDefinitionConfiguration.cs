using ApospReport.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApospReport.DataStore.Configurations
{
    internal class ItemDefinitionConfiguration : IEntityTypeConfiguration<ItemDefinition>
    {
        public void Configure(EntityTypeBuilder<ItemDefinition> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedNever();

            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entity.Property(x => x.IsStackable).IsRequired();

            entity.HasMany(x => x.InventoryItems).WithOne(x => x.Definition).IsRequired();
            entity.HasMany(x => x.BankItems).WithOne(x => x.Definition).IsRequired();
        }
    }
}
