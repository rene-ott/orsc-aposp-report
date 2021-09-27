using System.Collections.Generic;
using ApospReport.Contract;
using ApospReport.Contract.Common;
using MediatR;

namespace ApospReport.Application.GetItemImage
{
    public class GetItemImageQuery : IRequest<IList<ItemImageDto>>
    {
    }
}
