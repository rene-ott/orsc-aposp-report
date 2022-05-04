using System.Collections.Generic;
using ApospReport.Contract.AccountReport;
using MediatR;

namespace ApospReport.Application.AccountReport
{
    public class AccountReportQuery : IRequest<IList<AccountReportDto>>
    { }
}
