import { BankItem } from "../shared/models/bank-item.model";

export interface AccountReport {
    username: number;
    bankItems: BankItem[]
}