namespace ApospReport.Contract.AccountReport
{
    public class AccountReportSkillLevelDto
    {
        public int CurrentLevel { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }

        public int? XpUntilNextLevel { get; set; }
        public int? NextLevelXp { get; set; }
        public double? NextLevelCompletionPercentage { get; set; }
    }
}
