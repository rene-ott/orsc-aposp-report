using System.Collections.Generic;
using ApospReport.Contract;
using ApospReport.Contract.AccountReport;
using MediatR;

namespace ApospReport.Application.GetAccountReport
{
    public class GetAccountReportQuery : IRequest<IList<AccountReportDto>>
    { }
}
