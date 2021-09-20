﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ApospReport.API
{
    public static class ServiceConfiguration
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApospReport", Version = "v1" });
            });
        }
    }
}
