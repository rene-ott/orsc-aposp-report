using System.Collections.Generic;

namespace ApospReport.Contract.BankReport
{
    public class BankReportDto
    {
        public IList<BankReportItemDto> Items { get; set; } = new List<BankReportItemDto>();
    }
}
