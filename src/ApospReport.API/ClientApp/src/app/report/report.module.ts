import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountBankItemTableComponent } from './account-report/components/account-bank-table/account-bank-table.component';
import { ItemReportComponent } from './item-report/item-report.component';
import { AccountReportComponent } from './account-report/account-report.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';
import { ReportComponent } from './report.component';
import { ReportRoutingModule } from './report-routing.module';
import { TimeDiffPipe } from '../shared/time-diff.pipe';
import { ReportItemComponent } from './shared/components/report-item/report-item.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { AccountReportService } from './account-report/services/account-report.service';
import { ItemReportService } from './item-report/services/item-report.service';
import { MatDialogModule } from '@angular/material/dialog';
import { MatRadioModule } from '@angular/material/radio';
import { ItemReportItemDialogComponent } from './item-report-item-dialog/item-report-item-dialog.component';
import { ToStringPipe } from '../shared/to-string.pipe';
import { SurroundWithBracketsPipe } from '../shared/surround-with-brackets.pipe';
import { AccountLevelsComponent } from './account-report/components/account-levels/account-levels.component';
import { ImageDialogComponent } from './shared/components/image-dialog/image-dialog.component';
import { ImageComponent } from './shared/components/image/image.component';
import { AccountLevelsSkillComponent } from './account-report/components/account-levels-skill/account-levels-skill.component';
import { NaNumberPipe } from '../shared/pipes/na-number.pipe';
import { AccountInventoryTableComponent } from './account-report/components/account-inventory-table/account-inventory-table.component';
import { ItemReportItemCountPipe } from './shared/pipes/item-report-item-count.pipe';

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
    MatRadioModule,
  ],
  declarations: [
    ItemReportComponent,
    AccountReportComponent,
    AccountBankItemTableComponent,
    AccountInventoryTableComponent,
    ReportComponent,
    TimeDiffPipe,
    ToStringPipe,
    SurroundWithBracketsPipe,
    NaNumberPipe,
    ItemReportItemCountPipe,
    ReportItemComponent,
    ItemReportItemDialogComponent,
    ImageDialogComponent,
    ImageComponent,
    AccountLevelsComponent,
    AccountLevelsSkillComponent
  ],
  providers: [AccountReportService, ItemReportService],
  exports: [ReportComponent, MatTabsModule] // This needs to be exported to AppModule, otherwise error with [active] 
})
export class ReportModule { }
