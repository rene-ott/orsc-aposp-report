import { ReportItem } from "../../shared/components/report-item/report-item.model";
import { AccountReportSkill } from "./account-report-skill.model";

export interface AccountReport {
    username: string;
    bankViewTimestamp: string;
    reportTimestamp: string;
    bankItems: ReportItem[];
    skill: AccountReportSkill;
}