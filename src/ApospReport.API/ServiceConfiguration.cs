using ApospReport.API.Authentication;
using ApospReport.API.Samples;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace ApospReport.API
{
    public static class ServiceConfiguration
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddAuthentication("ApiKey")
                .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>("ApiKey", null);

            services.AddSingleton<IApiKeyAuthenticationValidator, ApiKeyAuthenticationValidator>();

            // Load static generated files from disk
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApospReport", Version = "v1" });
                c.ExampleFilters();
            });
            services.AddSwaggerExamplesFromAssemblyOf<SaveAccountReportExample>();
        }
    }
}
