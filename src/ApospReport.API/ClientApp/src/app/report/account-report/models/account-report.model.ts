import { BankItem } from "./bank-item.model";

export interface AccountReport {
    username: string;
    bankViewTimestamp: string;
    reportTimestamp: string;
    bankItems: BankItem[];
}