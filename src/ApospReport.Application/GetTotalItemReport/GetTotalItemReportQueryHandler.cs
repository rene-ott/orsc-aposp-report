using System.Threading;
using System.Threading.Tasks;
using ApospReport.Contract.TotalItemReport;
using ApospReport.Domain.Contracts;
using MediatR;

namespace ApospReport.Application.GetTotalItemReport
{
    internal class GetTotalItemReportQueryHandler : IRequestHandler<GetTotalItemReportQuery, ItemReportDto>
    {
        private readonly IGenericRepository genericRepository;
        private readonly IGetTotalItemReportQueryResultMapper resultMapper;

        public GetTotalItemReportQueryHandler(IGenericRepository genericRepository,
            IGetTotalItemReportQueryResultMapper resultMapper)
        {
            this.genericRepository = genericRepository;
            this.resultMapper = resultMapper;
        }

        public async Task<ItemReportDto> Handle(GetTotalItemReportQuery request, CancellationToken cancellationToken)
        {
            var items = await genericRepository.GetAllItemsWithAcounts();
            var result = resultMapper.MapResult(items);

            return result;
        }
    }

}
