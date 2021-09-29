using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApospReport.Contract.AccountReport;
using ApospReport.Domain.Contracts;
using MediatR;

namespace ApospReport.Application.GetAccountReport
{
    internal class GetAccountReportQueryHandler : IRequestHandler<GetAccountReportQuery, IList<AccountReportDto>>
    {
        private readonly IGenericRepository genericRepository;
        private readonly IGetAccountReportQueryResultMapper resultMapper;

        public GetAccountReportQueryHandler(IGenericRepository genericRepository,
                                            IGetAccountReportQueryResultMapper resultMapper)
        {
            this.genericRepository = genericRepository;
            this.resultMapper = resultMapper;
        }

        public async Task<IList<AccountReportDto>> Handle(GetAccountReportQuery request, CancellationToken cancellationToken)
        {
            var accounts = await genericRepository.GetAccountsWithItems();
            var result = resultMapper.MapResult(accounts);

            return result;
        }
    }
}
