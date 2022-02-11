using System.Collections.Generic;
using ApospReport.Contract.BankReport;
using ApospReport.Contract.Common;

namespace ApospReport.Contract.TotalItemReport
{
    public class TotalItemReportItemDto : ItemDefinitionDto
    {
        public int TotalItemCount { get; set; }
        public int BankItemCount { get; set; }
        public int InventoryItemCount { get; set; }
        public IList<TotalItemReportUserDto> Users { get; set; } = new List<TotalItemReportUserDto>();
    }
}
