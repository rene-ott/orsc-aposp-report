using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract.ItemReport;
using ApospReport.Domain.Models;

namespace ApospReport.Application.ItemReport
{
    internal interface IItemReportQueryResultMapper
    {
        ItemReportDto MapResult(IList<ItemDefinition> itemDefinitions);
    }

    internal class ItemReportQueryResultMapper : IItemReportQueryResultMapper
    {
        public ItemReportDto MapResult(IList<ItemDefinition> itemDefinitions)
        {
            var itemReportItems = new List<ItemReportItemDto>();

            foreach (var itemDefinition in itemDefinitions)
            {
                var inventoryItemCount = itemDefinition.InventoryItems.Sum(x => x.Count);
                var bankItemCount = itemDefinition.BankItems.Sum(x => x.Count);

                var reportItemDto = new ItemReportItemDto
                {
                    Id = itemDefinition.Id,
                    IsStackable = itemDefinition.IsStackable,
                    Name = itemDefinition.Name,
                    BankCount = bankItemCount,
                    InventoryCount = inventoryItemCount,
                    TotalCount = bankItemCount + inventoryItemCount
                };

                var accountsWithItems = itemDefinition
                    .BankItems.Cast<AccountItem>()
                    .Concat(itemDefinition.InventoryItems)
                    .GroupBy(x => x.Account);

                foreach (var accountWithItems in accountsWithItems)
                {
                    var accountItems = accountWithItems.ToList();

                    var accountBankItemCount = GetAccountItem<BankItem>(accountItems)?.Count ?? 0;
                    var accountInventoryItemCount = GetAccountItem<InventoryItem>(accountItems)?.Count ?? 0;

                    var accountItemDto = new ItemReportAccountItemDto
                    {
                        Username = accountWithItems.Key.Username,
                        BankCount = accountBankItemCount,
                        InventoryCount = accountInventoryItemCount,
                        TotalCount = accountBankItemCount + accountInventoryItemCount,
                    };
                    reportItemDto.Accounts.Add(accountItemDto);
                }

                itemReportItems.Add(reportItemDto);
            }

            return new ItemReportDto
            {
                Items = itemReportItems
            };
        }

        private static T GetAccountItem<T>(IEnumerable<AccountItem> accountItems) where T : AccountItem
        {
            return (T) accountItems.SingleOrDefault(x => x is T);
        }
    }
}
