using System;
using ApospReport.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApospReport.DataStore
{
    public static class ServiceConfiguration
    {
        public static void AddDataStoreServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApospReportDbContext>(options =>
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention()
            );
            services.AddScoped<IGenericRepository, GenericRepository>();

            services.AddSingleton<IDbInitializer, DbInitializer>();
        }

        public static void InitializeDatabase(this IServiceProvider serviceProvider, IHostEnvironment hostEnvironment)
        {
            var dbInitializer = serviceProvider.GetRequiredService<IDbInitializer>();
            dbInitializer.RunMigrations();
            dbInitializer.SeedData(hostEnvironment);
        }
    }
}
