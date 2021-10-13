import { AccountReportSkillLevel } from "./account-report-skill-level.model";

export interface AccountReportSkill {
    attack: AccountReportSkillLevel;
    defense: AccountReportSkillLevel;
    strength: AccountReportSkillLevel;
    prayer: AccountReportSkillLevel;
    ranged: AccountReportSkillLevel;
    agility: AccountReportSkillLevel;
    herblaw: AccountReportSkillLevel;
    cooking: AccountReportSkillLevel;
    crafting: AccountReportSkillLevel;
    firemaking: AccountReportSkillLevel;
    fishing: AccountReportSkillLevel;
    magic: AccountReportSkillLevel;
    mining: AccountReportSkillLevel;
    fletching: AccountReportSkillLevel;
    smithing: AccountReportSkillLevel;
    hits: AccountReportSkillLevel;
    thieving: AccountReportSkillLevel;
    woodcut: AccountReportSkillLevel;
}