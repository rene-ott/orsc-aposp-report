using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApospReport.Contract;
using ApospReport.Domain;
using MediatR;

namespace ApospReport.Application.GetItemImage
{
    internal class GetItemImageQueryHandler : IRequestHandler<GetItemImageQuery, IList<ItemImageDto>>
    {
        private readonly IItemImageService itemImageService;

        public GetItemImageQueryHandler(IItemImageService itemImageService)
        {
            this.itemImageService = itemImageService;
        }

        public Task<IList<ItemImageDto>> Handle(GetItemImageQuery request, CancellationToken cancellationToken)
        {
            var result = itemImageService.GetItemImages().Select(MapResult).ToList();

            return Task.FromResult<IList<ItemImageDto>>(result);
        }

        private static ItemImageDto MapResult((int id, string data, string extension) imageInfo)
        {
            return new ItemImageDto
            {
                Id = imageInfo.id,
                Data = imageInfo.data,
                Extension = imageInfo.extension
            };
        }
    }
}
