using System.Collections.Generic;
using ApospReport.Contract.Common;

namespace ApospReport.Contract.ItemReport
{
    public class ItemReportItemDto : ItemDefinitionDto
    {
        public int Count { get; set; }
        public int BankCount { get; set; }
        public int InventoryCount { get; set; }
        public IList<ItemReportAccountItemDto> Accounts { get; set; } = new List<ItemReportAccountItemDto>();
    }
}
