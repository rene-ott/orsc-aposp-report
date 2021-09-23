using ApospReport.Application.Mappers;
using ApospReport.Application.SaveAccountReport;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ApospReport.Application
{
    public static class ServiceConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(SaveAccountReportCommandHandler));
            services.AddScoped<ISkillMapper, SkillMapper>();
            services.AddScoped<IAccountItemMapper, AccountItemMapper>();
            services.AddScoped<IAccountMapper, AccountMapper>();
        }
    }
}
