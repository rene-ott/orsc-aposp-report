export interface AccountReportSkillLevel {
    level: number,
    currentLevel: number,
    xp: number,
    xpUntilNextLevel: number | null,
    nextLevelCompletionPercentage: number | null,
    nextLevelXp: number | null
}