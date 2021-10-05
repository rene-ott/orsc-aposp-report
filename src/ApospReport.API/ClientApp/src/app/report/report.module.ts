import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ItemImageService } from '../shared/services/item-image.service';
import { ItemSlotImageComponent } from '../shared/components/item-slot-image/item-slot-image.component';
import { AccountBankItemTableComponent } from './account-report/components/account-bank-table/account-bank-table.component';
import { BankReportComponent } from './bank/bank-report.component';
import { AccountReportComponent } from './account-report/account-report.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { ReportComponent } from './report.component';
import { ReportRoutingModule } from './report-routing.module';
import { TimeDiffPipe } from '../shared/time-diff.pipe';

@NgModule({
  imports: [
    CommonModule,
    MatTabsModule,
    MatButtonModule,
    MatTableModule,
    MatCardModule,
    ReportRoutingModule
  ],
  declarations: [
    ItemSlotImageComponent,
    BankReportComponent,
    AccountReportComponent,
    AccountBankItemTableComponent,
    ReportComponent,
    TimeDiffPipe
  ],
  providers: [ItemImageService],

  exports: [ReportComponent, MatTabsModule] // This needs to be exported to AppModule, otherwise error with [active] 
})
export class ReportModule { }