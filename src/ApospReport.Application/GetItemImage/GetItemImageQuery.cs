using System.Collections.Generic;
using ApospReport.Contract;
using MediatR;

namespace ApospReport.Application.GetItemImage
{
    public class GetItemImageQuery : IRequest<IList<ItemImageDto>>
    {
    }
}
