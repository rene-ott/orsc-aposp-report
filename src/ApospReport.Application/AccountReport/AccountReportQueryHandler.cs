using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApospReport.Contract.AccountReport;
using ApospReport.Domain.Contracts;
using MediatR;

namespace ApospReport.Application.AccountReport
{
    internal class AccountReportQueryHandler : IRequestHandler<AccountReportQuery, IList<AccountReportDto>>
    {
        private readonly IGenericRepository genericRepository;
        private readonly IAccountReportQueryResultMapper resultMapper;

        public AccountReportQueryHandler(IGenericRepository genericRepository,
                                            IAccountReportQueryResultMapper resultMapper)
        {
            this.genericRepository = genericRepository;
            this.resultMapper = resultMapper;
        }

        public async Task<IList<AccountReportDto>> Handle(AccountReportQuery request, CancellationToken cancellationToken)
        {
            var accounts = await genericRepository.GetAccountsWithItems();
            var result = resultMapper.MapResult(accounts);

            return result;
        }
    }
}
