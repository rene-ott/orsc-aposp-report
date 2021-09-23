using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract;
using ApospReport.Domain.Models;

namespace ApospReport.Application.Mappers
{
    internal interface IAccountItemMapper
    {
        IList<TAccountItem> MapFromDto<TAccountItem>(IList<AccountReportItemDto> items)
            where TAccountItem : AccountItem, new();
    }

    internal class AccountItemMapper : IAccountItemMapper
    {
        public IList<TAccountItem> MapFromDto<TAccountItem>(IList<AccountReportItemDto> items) where TAccountItem: AccountItem, new()
        {
            return items.Select(MapFromDto<TAccountItem>).ToList();
        }

        private static TAccountItem MapFromDto<TAccountItem>(AccountReportItemDto accountReportItem) where TAccountItem: AccountItem, new()
        {
            return new()
            {
                ItemDefinitionId = accountReportItem.Id,
                Count = accountReportItem.Count
            };
        }
    }
}
