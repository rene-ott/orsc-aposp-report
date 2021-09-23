using System;
using System.Collections.Generic;

namespace ApospReport.Contract
{
    public class AccountReportDto
    {
        public string Username { get; set; }

        public SkillDto Attack { get; set; }
        public SkillDto Defense { get; set; }
        public SkillDto Strength { get; set; }
        public SkillDto Hits { get; set; }
        public SkillDto Ranged { get; set; }
        public SkillDto Prayer { get; set; }
        public SkillDto Magic { get; set; }
        public SkillDto Cooking { get; set; }
        public SkillDto Woodcut { get; set; }
        public SkillDto Fletching { get; set; }
        public SkillDto Fishing { get; set; }
        public SkillDto Firemaking { get; set; }
        public SkillDto Crafting { get; set; }
        public SkillDto Smithing { get; set; }
        public SkillDto Mining { get; set; }
        public SkillDto Herblaw { get; set; }
        public SkillDto Agility { get; set; }
        public SkillDto Thieving { get; set; }

        public IList<AccountReportItemDto> InventoryItems { get; set; }
        public IList<AccountReportItemDto> BankItems { get; set; }

        public DateTime? BankViewTimestamp { get; set; }
    }
}
