import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BankReportComponent } from './bank-report.component';
import { AccountReportService } from '../account-report/account-report.service';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [BankReportComponent],
  providers:[AccountReportService]
})
export class BankReportModule { }
