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
import { MatDialogModule } from '@angular/material/dialog';
import { BankReportItemDialogComponent } from './bank-report-item-dialog/bank-report-item-dialog.component';
import { ToStringPipe } from '../shared/to-string.pipe';
import { SurroundWithBracketsPipe } from '../shared/surround-with-brackets.pipe';

@NgModule({
  imports: [
    CommonModule,
    MatTabsModule,
    MatButtonModule,
    MatTableModule,
    MatCardModule,
    ReportRoutingModule,
    MatDialogModule,
    MatTooltipModule,
  ],
  declarations: [
    BankReportComponent,
    AccountReportComponent,
    AccountBankItemTableComponent,
    ReportComponent,
    TimeDiffPipe,
    ToStringPipe,
    SurroundWithBracketsPipe,
    ReportItemComponent,
    BankReportItemDialogComponent
  ],
  providers: [AccountReportService, BankReportService],
  exports: [ReportComponent, MatTabsModule] // This needs to be exported to AppModule, otherwise error with [active] 
})
export class ReportModule { }
