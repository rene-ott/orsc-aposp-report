import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { ItemReportItem } from './models/item-report-item.model';
import { ItemReportService } from './services/item-report.service';
import * as _ from 'lodash'
import { ReportItemComponent } from '../shared/components/report-item/report-item.component';
import {MatDialog} from '@angular/material/dialog';
import { BankReportItemDialogComponent } from '../bank-report-item-dialog/bank-report-item-dialog.component';
import { ReportItemSelectionChangedEvent } from '../shared/components/report-item/report-item-selection-changed-event.model';

@Component({
  selector: 'app-bank-report',
  templateUrl: './bank-report.component.html',
  styleUrls: ['./bank-report.component.scss']
})
export class BankReportComponent implements OnInit {

  @ViewChildren('reportItem') reportItemComponents!: QueryList<ReportItemComponent>;

  selectedBankReportItems: ItemReportItem[] = [];

  rowSize = 10;
  bankReportItems: (ItemReportItem | null)[] = [];
  rowCount = 10

  constructor(private itemReportService: ItemReportService, public dialog: MatDialog)
  {}

  openBankReportItemDialog() {
    this.dialog.open(BankReportItemDialogComponent, {
      height: '600px',
      width: '800px',
      data: {
        items: this.selectedBankReportItems
    }});
  }

  onReportItemSelected(evt: ReportItemSelectionChangedEvent) {
    var bankReportItem = evt.item as ItemReportItem;

    if (!evt.isSelected) {
      _.remove(this.selectedBankReportItems, x => x == bankReportItem);
    } else {
      this.selectedBankReportItems.push(bankReportItem);
    }
  }

  ngOnInit() {
    this.itemReportService.getItemReport().subscribe(x => {
      this.bankReportItems = x.items;
      this.rowCount = this.getRowCount();
      _.times(this.getBankItemPlaceholderCount(), _ => this.appendPlaceholder());
    });
  }

  private getBankItemPlaceholderCount(): number {
    return (this.getRowCount() * this.rowSize - this.bankReportItems.length);
  }

  private appendPlaceholder() {
    this.bankReportItems.push(null)
  }

  getRowCount(): number {
    return Math.ceil(this.bankReportItems.length / this.rowSize)
  }
}
