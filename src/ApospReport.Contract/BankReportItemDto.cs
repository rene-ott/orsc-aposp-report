using System.Collections.Generic;

namespace ApospReport.Contract
{
    public class BankReportItemDto : ItemDefinitionDto
    {
        public int TotalItemCount { get; set; }
        public IList<BankReportUserDto> Users { get; set; } = new List<BankReportUserDto>();
    }
}
