import { ReportItem } from "../../shared/components/report-item/report-item.model";
import { ItemReportAccountItem } from "./item-report-account-item.model";

export interface ItemReportItem extends ReportItem {
    accounts: ItemReportAccountItem[]
}