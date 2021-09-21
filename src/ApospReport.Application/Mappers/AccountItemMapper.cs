using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract;
using ApospReport.Domain.Models;

namespace ApospReport.Application.Mappers
{
    internal interface IAccountItemMapper
    {
        IList<TAccountItem> MapFromReport<TAccountItem>(IList<ReportItemDto> items)
            where TAccountItem : AccountItem, new();
    }

    internal class AccountItemMapper : IAccountItemMapper
    {
        public IList<TAccountItem> MapFromReport<TAccountItem>(IList<ReportItemDto> items) where TAccountItem: AccountItem, new()
        {
            return items.Select(MapFromReport<TAccountItem>).ToList();
        }

        private static TAccountItem MapFromReport<TAccountItem>(ReportItemDto item) where TAccountItem: AccountItem, new()
        {
            return new()
            {
                DefinitionId = item.Id,
                Count = item.Count
            };
        }
    }
}
