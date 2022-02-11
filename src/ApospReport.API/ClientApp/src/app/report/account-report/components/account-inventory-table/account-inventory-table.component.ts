import { Component, Input, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { ReportItem } from 'src/app/report/shared/components/report-item/report-item.model';

@Component({
  selector: 'app-account-inventory-table',
  templateUrl: './account-inventory-table.component.html',
  styleUrls: ['./account-inventory-table.component.css']
})
export class AccountInventoryTableComponent implements OnInit {

  private readonly INVENTORY_SIZE: number = 30;

  private aligneditems: (ReportItem | null)[] = [];

  get items(): (ReportItem | null)[] {
    return this.aligneditems;
  }

  @Input()
  set items(val: (ReportItem | null)[]) {
    this.aligneditems = val;
    _.times(this.getInventoryItemPlaceholderCount(), _ => this.appendPlaceholder());
  }

  private getInventoryItemPlaceholderCount(): number {
    return (this.INVENTORY_SIZE - this.items.length);
  }

  private appendPlaceholder() {
    this.aligneditems.push(null)
  }

  constructor() { }

  ngOnInit() {
  }

}
