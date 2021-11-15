using System;
using System.Collections.Generic;

namespace ApospReport.Contract.AccountReport
{
    public class AccountReportDto
    {
        public string Username { get; set; }
        public string Base64EncodedScreenshot { get; set; }
        public DateTime? ReportTimestamp { get; set; }

        public AccountReportSkillDto Skill { get; set; }

        public IList<AccountReportItemDto> InventoryItems { get; set; }
        public IList<AccountReportItemDto> BankItems { get; set; }

        public DateTime? BankViewTimestamp { get; set; }
    }
}
