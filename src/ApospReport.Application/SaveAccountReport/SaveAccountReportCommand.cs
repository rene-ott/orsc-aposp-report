using ApospReport.Contract;
using ApospReport.Contract.AccountReport;
using MediatR;

namespace ApospReport.Application.SaveAccountReport
{
    public class SaveAccountReportCommand : IRequest
    {
        public AccountReportDto AccountReport { get; }

        public SaveAccountReportCommand(AccountReportDto accountReport)
        {
            AccountReport = accountReport;
        }
    }
}
