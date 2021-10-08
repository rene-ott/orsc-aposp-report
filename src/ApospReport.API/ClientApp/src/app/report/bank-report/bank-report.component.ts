import { Component, OnInit } from '@angular/core';
import { BankReportItem } from './models/bank-report-item.model';
import { BankReportService } from './services/bank-report.service';
import * as _ from 'lodash'

@Component({
  selector: 'app-bank-report',
  templateUrl: './bank-report.component.html',
  styleUrls: ['./bank-report.component.scss']
})
export class BankReportComponent implements OnInit {

  rowSize = 10;
  bankReportItems: (BankReportItem | null)[] = [];
  rowCount = 10

  constructor(private bankReportService: BankReportService)
  {}

  ngOnInit() {
    this.bankReportService.getBankReportItems().subscribe(x => {
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
