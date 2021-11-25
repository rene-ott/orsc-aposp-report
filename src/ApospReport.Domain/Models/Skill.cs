namespace ApospReport.Domain.Models
{
    public class Skill
    {
        public int Xp { get; set; }
        public int CurrentLevel { get; set; }
        public int Level { get; set; }

        private bool IsFinalLevel => Level == 99;
        public int? NextLevel => IsFinalLevel ? null : Level + 1;

        // ReSharper disable once PossibleInvalidOperationException
        public int? NextLevelXp => IsFinalLevel
            ? null
            : LevelTable.GetXp(NextLevel.Value);
        
        public double? NextLevelCompletionPercentage => NextLevel == null
            ? null
            :  ((double?)XpDifferenceFromLevel/XpDifferenceBetweenNextLevelAndLevel) * 100;

        public int? XpUntilNextLevel => IsFinalLevel ? null :  XpDifferenceBetweenNextLevelAndLevel - XpDifferenceFromLevel;

        private int? XpDifferenceBetweenNextLevelAndLevel => IsFinalLevel ? null : NextLevelXp - LevelTable.GetXp(Level);
        private int? XpDifferenceFromLevel => IsFinalLevel ? null : Xp - LevelTable.GetXp(Level);
    }
}
