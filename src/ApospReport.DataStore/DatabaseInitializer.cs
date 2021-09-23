using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using ApospReport.Domain;
using ApospReport.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApospReport.DataStore
{
    public interface IDbInitializer
    {
        void RunMigrations();
        void SeedData();
    }

    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public void RunMigrations()
        {
            using var serviceScope = scopeFactory.CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<ApospReportDbContext>();
            context.Database.Migrate();
        }

        public void SeedData()
        {
            using var serviceScope = scopeFactory.CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<ApospReportDbContext>();

            if (context.ItemDefinitions.Any())
                return;

            context.AddRange(GetAllItemDefinitions().ToList());
            context.SaveChanges();
        }

        private static IEnumerable<ItemDefinition> GetAllItemDefinitions()
        {
            var root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(root, "Seed", "ItemDefinitions.json");
            var json = File.ReadAllText(path);
            var items = JsonSerializer.Deserialize<IList<ItemDefinition>>(json);

            return items;
        }
    }
}
