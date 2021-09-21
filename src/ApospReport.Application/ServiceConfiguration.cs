using ApospReport.Application.Mappers;
using ApospReport.Application.SaveReport;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ApospReport.Application
{
    public static class ServiceConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(SaveReportCommandHandler));
            services.AddScoped<ISkillMapper, SkillMapper>();
            services.AddScoped<IAccountItemMapper, AccountItemMapper>();
        }
    }
}
