import { Component, OnInit, Input } from '@angular/core';
import { BankItem } from 'src/app/shared/models/bank-item.model';
import * as _ from 'lodash'
import { MatTabChangeEvent } from '@angular/material/tabs';

@Component({
  selector: 'app-account-bank-item-table',
  templateUrl: './account-bank-item-table.component.html',
  styleUrls: ['./account-bank-item-table.component.css']
})
export class AccountBankItemTableComponent implements OnInit {
  
  private alignedBankItems: Array<BankItem | null> = [];

  private readonly MAX_PAGE_COUNT = 4;
  private readonly PAGE_SIZE = 48;
  private readonly BANK_SIZE = 192;

  currentPageIndex = 0;
  pageCount = 1
  currentPageItems:any[] = Array.from({length: this.PAGE_SIZE}, () => null) 

  get bankItems(): any { 
    return this.alignedBankItems;
  }
  
  @Input()
  set bankItems(val: BankItem[]) {
    this.alignedBankItems = val;
    _.times(this.getBankItemPlaceholderCount(), _ => this.appendPlaceholder());
  }

  private getBankItemPlaceholderCount(): number {
    return (this.BANK_SIZE - this.bankItems.length);
  }

  private appendPlaceholder() {
    this.alignedBankItems.push(null)
  }

  openPage(tabChangeEvent: MatTabChangeEvent) {
    this.currentPageIndex = tabChangeEvent.index
    this.currentPageItems = this.getPageItems();
  }

  ngOnInit(): void {
    this.pageCount = this.getPageCount();
    this.currentPageItems = this.getPageItems();
  }

  private getPageItems(): any[] {
    var firstItemIndexOnPage = this.currentPageIndex * this.PAGE_SIZE;
    var lastItemIndexOnPage = firstItemIndexOnPage + (this.isLastPage() ? this.getLastPageItemCount() : this.PAGE_SIZE)
    return this.alignedBankItems.slice(firstItemIndexOnPage, lastItemIndexOnPage)
  }

  private isLastPage() {
    return this.currentPageIndex == this.MAX_PAGE_COUNT;
  }

  private getLastPageItemCount() {
    return this.getTotalItemCount() - (this.getPageCount() * this.PAGE_SIZE)
  }

  private getPageCount(): number {
    return Math.ceil(this.getTotalItemCount() / this.PAGE_SIZE)
  }

  private getTotalItemCount(): number {
    return this.alignedBankItems.filter(x => x != null).length;
  }
}
