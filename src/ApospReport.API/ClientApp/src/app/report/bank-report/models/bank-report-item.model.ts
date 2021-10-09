import { ReportItem } from "../../shared/components/report-item/report-item.model";
import { BankReportUser } from "./bank-report-user.model";

export interface BankReportItem extends ReportItem {
    users: BankReportUser[]
}