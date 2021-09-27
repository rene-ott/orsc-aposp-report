using System.Collections.Generic;
using ApospReport.Contract;
using ApospReport.Contract.BankReport;
using MediatR;

namespace ApospReport.Application.GetTotalBankReport
{
    public class GetTotalBankItemReportQuery : IRequest<IList<BankReportItemDto>>
    {
    }
}
