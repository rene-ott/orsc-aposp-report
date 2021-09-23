using System.Collections.Generic;
using ApospReport.Contract;
using MediatR;

namespace ApospReport.Application.GetTotalBankReport
{
    public class GetTotalBankItemReportQuery : IRequest<IList<BankReportItemDto>>
    {
    }
}
