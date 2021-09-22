using ApospReport.Contract;
using MediatR;

namespace ApospReport.Application.SaveAccountReport
{
    public class SaveAccountReportCommand : IRequest
    {
        public AccountDto Account { get; }

        public SaveAccountReportCommand(AccountDto account)
        {
            Account = account;
        }
    }
}
