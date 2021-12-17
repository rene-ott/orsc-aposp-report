namespace ApospReport.Contract.AccountReport
{
    public class AccountReportSkillDto
    {
        public AccountReportSkillLevelDto Attack { get; set; }
        public AccountReportSkillLevelDto Defense { get; set; }
        public AccountReportSkillLevelDto Strength { get; set; }
        public AccountReportSkillLevelDto Hits { get; set; }
        public AccountReportSkillLevelDto Ranged { get; set; }
        public AccountReportSkillLevelDto Prayer { get; set; }
        public AccountReportSkillLevelDto Magic { get; set; }
        public AccountReportSkillLevelDto Cooking { get; set; }
        public AccountReportSkillLevelDto Woodcut { get; set; }
        public AccountReportSkillLevelDto Fletching { get; set; }
        public AccountReportSkillLevelDto Fishing { get; set; }
        public AccountReportSkillLevelDto Firemaking { get; set; }
        public AccountReportSkillLevelDto Crafting { get; set; }
        public AccountReportSkillLevelDto Smithing { get; set; }
        public AccountReportSkillLevelDto Mining { get; set; }
        public AccountReportSkillLevelDto Herblaw { get; set; }
        public AccountReportSkillLevelDto Agility { get; set; }
        public AccountReportSkillLevelDto Thieving { get; set; }

        public int TotalLevel { get; set; }
    }
}
