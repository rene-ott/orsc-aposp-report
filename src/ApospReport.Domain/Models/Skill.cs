namespace ApospReport.Domain.Models
{
    public class Skill
    {
        public int CurrentLevel { get; set; }
        public int BaseLevel { get; set; }
        public int TotalXp { get; set; }

        public int NextLevelXp => BaseLevel == 99
            ? 0
            : SkillXpTable.GetLevelXp(BaseLevel + 1);

        public int ThisLevelXp => SkillXpTable.GetLevelXp(BaseLevel);

        public int XpDifferenceBetweenNextAndThisLevel => BaseLevel == 99 ? 0 : NextLevelXp - ThisLevelXp;

    }
}
