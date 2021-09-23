using System.Collections.Generic;
using ApospReport.Contract;
using MediatR;

namespace ApospReport.Application.GetAccountReport
{
    public class GetAccountReportQuery : IRequest<IList<AccountReportDto>>
    { }
}
