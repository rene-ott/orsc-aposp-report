namespace ApospReport.Contract.AccountReport
{
    public class AccountReportSkillLevelDto
    {
        public int Current { get; set; }
        public int Base { get; set; }
        public int TotalXp { get; set; }
        public int XpLeftToNextLevel { get; set; }
        public int NextLevelXp { get; set; }
        public decimal PercentageDoneForNextLevel { get; set; }
    }
}
