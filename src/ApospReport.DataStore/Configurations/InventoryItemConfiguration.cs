using ApospReport.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApospReport.DataStore.Configurations
{
    internal class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
    {
        public void Configure(EntityTypeBuilder<InventoryItem> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Position).IsRequired();
            entity.Property(x => x.Count).IsRequired();
        }
    }
}
