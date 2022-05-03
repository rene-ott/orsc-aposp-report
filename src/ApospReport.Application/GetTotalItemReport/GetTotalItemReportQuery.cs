using ApospReport.Contract.BankReport;
using ApospReport.Contract.TotalItemReport;
using MediatR;

namespace ApospReport.Application.GetTotalItemReport
{
    public class GetTotalItemReportQuery : IRequest<ItemReportDto>
    {
    }
}
