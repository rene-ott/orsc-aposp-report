using System;
using ApospReport.API.Authentication;
using ApospReport.API.Samples;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace ApospReport.API
{
    internal static class ServiceConfiguration
    {
        internal static void AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("ApiKey").AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>("ApiKey", null);
            services.AddAuthorization();

            services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();

            // Load static generated files from disk
            services.AddSpaStaticFiles(conf =>
            {
                conf.RootPath = "ClientApp/dist";
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<ApiKeyHeaderOperationFilter>();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApospReport", Version = "v1" });
                c.ExampleFilters();
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "X-API-KEY"
                });
            });
            services.AddSwaggerExamplesFromAssemblyOf<SaveAccountReportExample>();
        }
    }
}
