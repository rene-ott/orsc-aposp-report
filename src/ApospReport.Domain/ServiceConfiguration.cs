using ApospReport.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApospReport.Domain
{
    public static class ServiceConfiguration
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IItemDefinitionService, ItemDefinitionService>();
            services.AddMemoryCache();
        }
    }
}
