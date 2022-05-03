using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract.TotalItemReport;
using ApospReport.Domain.Models;

namespace ApospReport.Application.GetTotalItemReport
{
    internal interface IGetTotalItemReportQueryResultMapper
    {
        ItemReportDto MapResult(IList<ItemDefinition> itemDefinitions);
    }

    internal class GetTotalItemReportQueryResultMapper : IGetTotalItemReportQueryResultMapper
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
                    if (accountItems.Count < 2)
                    {

                    }
                    var accountBankItemCount = accountItems[0]?.Count ?? 0;
                    var accountInventoryItemCount = accountItems[1]?.Count ?? 0;

                    var useItems = new ItemReportAccountItemDto
                    {
                        Username = accountWithItems.Key.Username,
                        BankCount = accountBankItemCount,
                        InventoryCount = accountInventoryItemCount,
                        TotalCount = accountBankItemCount + accountInventoryItemCount,
                    };
                    reportItemDto.Accounts.Add(useItems);
                }
            }

            return new ItemReportDto
            {
                Items = itemReportItems
            };
        }
    }
}
