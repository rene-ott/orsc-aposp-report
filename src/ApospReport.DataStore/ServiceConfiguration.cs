using System;
using ApospReport.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApospReport.DataStore
{
    public static class ServiceConfiguration
    {
        public static void AddDataStoreServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApospReportDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IGenericRepository, GenericRepository>();
        }

        public static void RunDbMigrations(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetRequiredService<ApospReportDbContext>().Database.Migrate();
        }
    }
}
