using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace ApospReport.Domain
{
    public static class ServiceConfiguration
    {
        // TODO: Move infra service reg out from here
        public static void AddDomainServices(this IServiceCollection services, IFileProvider fileProvider)
        {
            services.AddScoped<IItemImageService, ItemImageService>();
            services.AddMemoryCache();
            services.AddSingleton(fileProvider);
        }
    }
}
