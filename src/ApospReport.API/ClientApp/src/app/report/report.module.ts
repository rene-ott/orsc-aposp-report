import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountBankItemTableComponent } from './account-report/components/account-bank-table/account-bank-table.component';
import { BankReportComponent } from './bank-report/bank-report.component';
import { AccountReportComponent } from './account-report/account-report.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { ReportComponent } from './report.component';
import { ReportRoutingModule } from './report-routing.module';
import { TimeDiffPipe } from '../shared/time-diff.pipe';
import { ReportItemComponent } from './shared/components/report-item/report-item.component';
import {MatTooltipModule} from '@angular/material/tooltip';
import { AccountReportService } from './account-report/services/account-report.service';
import { BankReportService } from './bank-report/services/bank-report.service';

@NgModule({
  imports: [
    CommonModule,
    MatTabsModule,
    MatButtonModule,
    MatTableModule,
    MatCardModule,
    ReportRoutingModule,
    MatTooltipModule,
  ],
  declarations: [
    BankReportComponent,
    AccountReportComponent,
    AccountBankItemTableComponent,
    ReportComponent,
    TimeDiffPipe,
    ReportItemComponent
  ],
  providers: [AccountReportService, BankReportService],
  exports: [ReportComponent, MatTabsModule] // This needs to be exported to AppModule, otherwise error with [active] 
})
export class ReportModule { }
