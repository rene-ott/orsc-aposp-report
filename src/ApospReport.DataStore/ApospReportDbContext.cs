using ApospReport.DataStore.Configurations;
using ApospReport.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApospReport.DataStore
{
    internal class ApospReportDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<BankItem> BankItems { get; set; }
        public DbSet<ItemDefinition> ItemDefinitions { get; set; }

        public ApospReportDbContext(DbContextOptions<ApospReportDbContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new BankItemConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryItemConfiguration());
            modelBuilder.ApplyConfiguration(new ItemDefinitionConfiguration());
        }
    }
}
