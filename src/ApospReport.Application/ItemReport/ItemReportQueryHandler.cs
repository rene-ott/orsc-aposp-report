using System.Threading;
using System.Threading.Tasks;
using ApospReport.Contract.ItemReport;
using ApospReport.Domain.Contracts;
using MediatR;

namespace ApospReport.Application.ItemReport
{
    internal class ItemReportQueryHandler : IRequestHandler<ItemReportQuery, ItemReportDto>
    {
        private readonly IGenericRepository genericRepository;
        private readonly IItemReportQueryResultMapper resultMapper;

        public ItemReportQueryHandler(IGenericRepository genericRepository,
            IItemReportQueryResultMapper resultMapper)
        {
            this.genericRepository = genericRepository;
            this.resultMapper = resultMapper;
        }

        public async Task<ItemReportDto> Handle(ItemReportQuery request, CancellationToken cancellationToken)
        {
            var items = await genericRepository.GetAllItemsWithAcounts();
            var result = resultMapper.MapResult(items);

            return result;
        }
    }

}
