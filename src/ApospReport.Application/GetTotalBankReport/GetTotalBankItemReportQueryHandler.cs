using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApospReport.Contract;
using ApospReport.Domain.Contracts;
using MediatR;

namespace ApospReport.Application.GetTotalBankReport
{
    internal class GetTotalBankItemReportQueryHandler : IRequestHandler<GetTotalBankItemReportQuery, IList<BankReportItemDto>>
    {
        private readonly IGenericRepository genericRepository;
        private readonly IGetTotalBankItemReportQueryResultMapper resultMapper;

        public GetTotalBankItemReportQueryHandler(IGenericRepository genericRepository,
                    IGetTotalBankItemReportQueryResultMapper resultMapper)
        {
            this.genericRepository = genericRepository;
            this.resultMapper = resultMapper;
        }

        public async Task<IList<BankReportItemDto>> Handle(GetTotalBankItemReportQuery request, CancellationToken cancellationToken)
        {
            var items = await genericRepository.GetBankItemsWithAccounts();
            var result = resultMapper.MapResult(items);

            return result;
        }
    }
}
