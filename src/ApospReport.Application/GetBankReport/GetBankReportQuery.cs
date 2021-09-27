using ApospReport.Contract.BankReport;
using MediatR;

namespace ApospReport.Application.GetBankReport
{
    public class GetTotalBankItemReportQuery : IRequest<BankReportDto>
    {
    }
}
