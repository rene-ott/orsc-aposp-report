using System;
using System.Collections.Generic;

namespace ApospReport.Contract
{
    public class ReportDto
    {
        public string Username { get; set; }

        public IList<ReportSkillDto> Skills { get; set; }

        public IList<ReportItemDto> InventoryItems { get; set; }
        public IList<ReportItemDto> BankItems { get; set; }

        public DateTime? BankViewTimestamp { get; set; }
    }
}
