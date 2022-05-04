using ApospReport.Application.AccountReport;
using ApospReport.Application.GetBankReport;
using ApospReport.Application.ItemReport;
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

            services.AddSingleton<ISaveAccountReportCommandInputMapper, SaveAccountReportCommandInputMapper>();
            services.AddSingleton<IItemReportQueryResultMapper, ItemReportQueryResultMapper>();
            services.AddSingleton<IGetBankReportQueryResultMapper, GetBankReportQueryResultMapper>();
            services.AddSingleton<IAccountReportQueryResultMapper, AccountReportQueryResultMapper>();
        }
    }
}
