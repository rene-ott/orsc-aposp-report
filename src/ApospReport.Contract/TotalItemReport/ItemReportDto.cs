using System.Collections.Generic;

namespace ApospReport.Contract.TotalItemReport
{
    public class ItemReportDto
    {
        public IList<ItemReportItemDto> Items { get; set; } = new List<ItemReportItemDto>();
    }
}
