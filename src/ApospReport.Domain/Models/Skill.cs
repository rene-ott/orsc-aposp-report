namespace ApospReport.Domain.Models
{
    public class Skill
    {
        public int CurrentLevel { get; set; }
        public int BaseLevel { get; set; }
        public int TotalXp { get; set; }
        public decimal PercentageDoneForNextLevel => XpPastThisLevel / (decimal)XpDifferenceBetweenNextAndThisLevel;
        public int XpLeftToNextLevel => XpDifferenceBetweenNextAndThisLevel - XpPastThisLevel;

        public int NextLevelXp => BaseLevel == 99
            ? 0
            : SkillXpTable.GetLevelXp(BaseLevel + 1);

        private int ThisLevelXp => SkillXpTable.GetLevelXp(BaseLevel);

        private int XpDifferenceBetweenNextAndThisLevel => BaseLevel == 99 ? 0 : NextLevelXp - ThisLevelXp;
        private int XpPastThisLevel => TotalXp - ThisLevelXp;

    }
}
