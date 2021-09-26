export interface BankReportItem {
    id: number;
    name: string;
    base64: string,
    totalItemCount: number,
    users: BankReportItem[]
}