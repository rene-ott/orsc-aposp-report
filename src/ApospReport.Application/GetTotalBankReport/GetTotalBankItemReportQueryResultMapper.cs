using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract;
using ApospReport.Domain.Models;

namespace ApospReport.Application.GetTotalBankReport
{
    internal interface IGetTotalBankItemReportQueryResultMapper
    {
        IList<BankReportItemDto> MapResult(IList<ItemDefinition> itemDefinition);
    }

    internal class GetTotalBankItemReportQueryResultMapper : IGetTotalBankItemReportQueryResultMapper
    {

        public IList<BankReportItemDto> MapResult(IList<ItemDefinition> itemDefinition)
        {
            var bankItemsPerIdGroups = itemDefinition.SelectMany(x => x.BankItems)
                .GroupBy(x => x.ItemDefinitionId);


            var bankReportItems = new List<BankReportItemDto>();
            foreach (var bankItemGroup in bankItemsPerIdGroups)
            {
                var bankItems = bankItemGroup.ToList();
                var itemDef = bankItems.First().ItemDefinition;

                var bankReportItem = new BankReportItemDto
                {
                    Id = bankItemGroup.Key,
                    IsStackable = itemDef.IsStackable,
                    Name = itemDef.Name,
                    TotalItemCount = bankItems.Sum(x => x.Count)
                };


                foreach (var bankItem in bankItems)
                {
                    var bankReportUser = new BankReportUserDto
                    {
                        Username = bankItem.Account.Username,
                        ItemCount = bankItem.Count,
                    };

                    bankReportItem.Users.Add(bankReportUser);
                }

                bankReportItems.Add(bankReportItem);
            }

            return bankReportItems;
        }
    }
}
