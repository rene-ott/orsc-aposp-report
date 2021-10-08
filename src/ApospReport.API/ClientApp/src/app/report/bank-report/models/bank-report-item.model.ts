import { ReportItem } from "../../shared/components/report-item/report-item.model";

export interface BankReportItem extends ReportItem {
    users: BankReportItem[]
}