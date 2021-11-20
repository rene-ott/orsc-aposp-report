import { ReportItem } from "../../shared/components/report-item/report-item.model";
import { AccountReportSkill } from "./account-report-skill.model";

export interface AccountReport {
    username: string;
    base64EncodedScreenshot: string;
    bankViewTimestamp: string;
    reportTimestamp: string;
    bankItems: ReportItem[];
    skill: AccountReportSkill;
}