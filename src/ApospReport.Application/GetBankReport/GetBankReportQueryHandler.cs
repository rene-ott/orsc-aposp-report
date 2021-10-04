using System.Threading;
using System.Threading.Tasks;
using ApospReport.Contract.BankReport;
using ApospReport.Domain.Contracts;
using MediatR;

namespace ApospReport.Application.GetBankReport
{
    internal class GetBankReportQueryHandler : IRequestHandler<GetTotalBankItemReportQuery, BankReportDto>
    {
        private readonly IGenericRepository genericRepository;
        private readonly IGetBankReportQueryResultMapper resultMapper;

        public GetBankReportQueryHandler(IGenericRepository genericRepository,
                    IGetBankReportQueryResultMapper resultMapper)
        {
            this.genericRepository = genericRepository;
            this.resultMapper = resultMapper;
        }

        public async Task<BankReportDto> Handle(GetTotalBankItemReportQuery request, CancellationToken cancellationToken)
        {
            var items = await genericRepository.GetBankItemsWithAccounts();
            var result = resultMapper.MapResult(items);

            return result;
        }
    }
}
