using ApospReport.Application;
using ApospReport.DataStore;
using ApospReport.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApospReport.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IHostEnvironment hostEnvironment;

        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            this.hostEnvironment = hostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAPIServices(Configuration);
            services.AddApplicationServices();
            services.AddDomainServices(hostEnvironment.ContentRootFileProvider);
            services.AddDataStoreServices(Configuration["ConnectionString"]);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // production SPA static files
            if (env.IsProduction())
                app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApospReport v1"));

            app.ApplicationServices.InitializeDatabase(env);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spaBuilder =>
            {
                if (env.IsDevelopment())
                    spaBuilder.UseProxyToSpaDevelopmentServer("http://localhost:4200");
            });
        }
    }
}
