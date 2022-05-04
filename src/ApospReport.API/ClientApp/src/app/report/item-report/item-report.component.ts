import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { ItemReportItem } from './models/item-report-item.model';
import { ItemReportService } from './services/item-report.service';
import * as _ from 'lodash'
import { ReportItemComponent } from '../shared/components/report-item/report-item.component';
import {MatDialog} from '@angular/material/dialog';
import { ItemReportItemDialogComponent } from '../item-report-item-dialog/item-report-item-dialog.component';
import { ReportItemSelectionChangedEvent } from '../shared/components/report-item/report-item-selection-changed-event.model';
import { MatRadioChange } from '@angular/material/radio';

@Component({
  selector: 'app-bank-report',
  templateUrl: './item-report.component.html',
  styleUrls: ['./item-report.component.scss']
})
export class ItemReportComponent implements OnInit {

  @ViewChildren('reportItem') reportItemComponents!: QueryList<ReportItemComponent<ItemReportItem>>;

  selectedBankReportItems: ItemReportItem[] = [];

  rowSize = 10;
  bankReportItems: (ItemReportItem | null)[] = [];
  rowCount = 10

  itemReportCountVisibility: ItemReportVisibility = ItemReportVisibility.All

  constructor(private itemReportService: ItemReportService, public dialog: MatDialog)
  {}

  public get itemReportVisibility(): typeof ItemReportVisibility {
    return ItemReportVisibility; 
  }

  showCountRadioChanged($event: MatRadioChange) {
    this.itemReportCountVisibility = $event.value;
  }
  
  openBankReportItemDialog() {
    this.dialog.open(ItemReportItemDialogComponent, {
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
