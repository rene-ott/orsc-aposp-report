import { Component, OnInit } from '@angular/core';
import { ItemImageService } from '../shared/services/item-image.service';
import { BankReportItem } from './bank-report-item.model';
import { BankReportService } from './bank-report.service';
import * as _ from 'lodash'

@Component({
  selector: 'app-bank-report',
  templateUrl: './bank-report.component.html',
  styleUrls: ['./bank-report.component.css']
})
export class BankReportComponent implements OnInit {

  rowSize = 10;
  bankReportItems: any = [];
  rowCount = 10

  constructor(private bankReportService: BankReportService,
              private itemImageService: ItemImageService)
  { }

  ngOnInit() {
    this.bankReportService.getBankReportItems().subscribe(x => {
      this.bankReportItems = x.items;
      this.rowCount = this.getRowCount();
      this.setBase64ImageToBankItems(this.bankReportItems)
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

  setBase64ImageToBankItems(bankItems: BankReportItem[]) {
    var itemImages = this.itemImageService.getItemImages();

    bankItems.forEach(x => {
      var foundImage = itemImages.find(i => i.id == x.id);
      x.base64 = foundImage!!.data
    });
  }

}
