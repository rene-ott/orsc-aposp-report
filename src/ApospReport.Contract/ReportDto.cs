using System;
using System.Collections.Generic;

namespace ApospReport.Contract
{
    public class ReportDto
    {
        public DateTime Timestamp { get; set; }
        public string Username { get; set; }

        public IList<ItemDto> InventoryItems { get; set; }
        public IList<SkillDto> SkillLevels { get; set; }

        public DateTime LastViewedBankTimestamp { get; set; }
        public IList<ItemDto> BankItems { get; set; }
    }
}
