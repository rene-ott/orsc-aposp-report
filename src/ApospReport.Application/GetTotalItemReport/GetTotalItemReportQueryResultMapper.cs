using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract.TotalItemReport;
using ApospReport.Domain.Models;

namespace ApospReport.Application.GetTotalItemReport
{
    internal interface IGetTotalItemReportQueryResultMapper
    {
        TotalItemReportDto MapResult(IList<ItemDefinition> itemDefinitions);
    }

    internal class GetTotalItemReportQueryResultMapper : IGetTotalItemReportQueryResultMapper
    {
        public TotalItemReportDto MapResult(IList<ItemDefinition> itemDefinitions)
        {
            var itemDefinitionGroups = GetAccountItemsGroupedByItemDefinition(itemDefinitions);

            var totalItemReportItems = new List<TotalItemReportItemDto>();
            foreach (var itemDefinitionGroup in itemDefinitionGroups)
            {
                var items = itemDefinitionGroup.ToList();

                var inventoryItems = FilterByItemType<InventoryItem>(itemDefinitionGroup);
                var bankItems = FilterByItemType<BankItem>(itemDefinitionGroup);
                var itemDefinition = GetItemDefinition(inventoryItems, bankItems);

                var inventoryItemCount = inventoryItems.Sum(x => x.Count);
                var bankItemCount = bankItems.Sum(x => x.Count);

                var reportItem = new TotalItemReportItemDto
                {
                    Id = itemDefinitionGroup.Key,
                    IsStackable = itemDefinition.IsStackable,
                    Name = itemDefinition.Name,
                    BankItemCount = bankItemCount,
                    InventoryItemCount = inventoryItemCount,
                    TotalItemCount = bankItemCount + inventoryItemCount
                };

                // WIP
                foreach (var item in items)
                {
                    var bankReportUser = new TotalItemReportUserDto
                    {
                        Username = item.Account.Username,
                    };
                }
            }

            return new TotalItemReportDto();
        }

        private static ItemDefinition GetItemDefinition(IList<InventoryItem> inventoryItems, IList<BankItem> bankItems)
        {
            return inventoryItems.FirstOrDefault()?.ItemDefinition ??
                   bankItems.FirstOrDefault()?.ItemDefinition;
        }

        private static IList<TAccountItem> FilterByItemType<TAccountItem>(IEnumerable<AccountItem> itemDefinitionGroup)
            where TAccountItem : AccountItem
        {
            return itemDefinitionGroup.Where(x => x is TAccountItem).Cast<TAccountItem>().ToList();
        }

        private static IEnumerable<IGrouping<int, AccountItem>> GetAccountItemsGroupedByItemDefinition(IList<ItemDefinition> itemDefinitions)
        {
            return itemDefinitions
                .SelectMany(x => x.BankItems.Cast<AccountItem>())
                .Concat(itemDefinitions.SelectMany(x => x.InventoryItems.Cast<AccountItem>()))
                .GroupBy(x => x.ItemDefinitionId);
        }
    }
}
