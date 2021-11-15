namespace ApospReport.Domain.Models
{
    public class Skill
    {
        public int CurrentLevel { get; set; }
        public int BaseLevel { get; set; }
        public int TotalXp { get; set; }

        public int NextLevelXp => BaseLevel == 99 ? 0 : SkillXpTable.GetLevelXp(BaseLevel);
        public int XpToNextLevel => NextLevelXp - TotalXp;
    }
}
