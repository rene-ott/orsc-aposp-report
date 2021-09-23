using ApospReport.Contract;
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
