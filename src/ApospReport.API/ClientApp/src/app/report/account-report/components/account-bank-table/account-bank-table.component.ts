import { Component, OnInit, Input } from '@angular/core';
import * as _ from 'lodash';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { ReportItem } from 'src/app/report/shared/components/report-item/report-item.model';

@Component({
  selector: 'app-account-bank-table',
  templateUrl: './account-bank-table.component.html',
  styleUrls: ['./account-bank-table.component.scss']
})
export class AccountBankItemTableComponent implements OnInit {

  private alignedBankItems: (ReportItem | null)[] = [];

  private readonly MAX_PAGE_COUNT: number = 4;
  private readonly PAGE_SIZE: number = 48;
  private readonly BANK_SIZE: number = 192;

  currentPageIndex: number = 0;
  pageCount: number = 1
  isDataAvailable:boolean = false;

  currentPageItems: (ReportItem | null)[] = Array.from({ length: this.PAGE_SIZE }, () => null)
  currentPageFirstRowItems: (ReportItem | null)[] = [];
  currentPageSecondRowItems: (ReportItem | null)[] = [];
  currentPageThirdRowItems: (ReportItem | null)[] = [];
  currentPageFourthRowItems: (ReportItem | null)[] = [];
  currentPageFifthRowItems: (ReportItem | null)[] = [];
  currentPageSixthRowItems: (ReportItem | null)[] = [];

  get bankItems(): (ReportItem | null)[] {
    return this.alignedBankItems;
  }

  @Input()
  set bankItems(val: (ReportItem | null)[]) {
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
    this.setCurrentPageItems();
  }

  ngOnInit(): void {
    this.pageCount = this.getPageCount();
    this.setCurrentPageItems();

    this.isDataAvailable = this.getRealPageCount() > 0;
  }

  setCurrentPageItems() {
    this.currentPageItems = this.getPageItems();

    this.currentPageFirstRowItems = this.currentPageItems.slice(0, 8);
    this.currentPageSecondRowItems = this.currentPageItems.slice(8, 16);
    this.currentPageThirdRowItems = this.currentPageItems.slice(16, 24);
    this.currentPageFourthRowItems = this.currentPageItems.slice(24, 32);
    this.currentPageFifthRowItems = this.currentPageItems.slice(32, 40);
    this.currentPageSixthRowItems = this.currentPageItems.slice(40, 48);
  }

  private getPageItems(): (ReportItem | null)[] {
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

  private getRealPageCount(): number {
    return Math.ceil(this.getTotalItemCount() / this.PAGE_SIZE);
  }

  private getPageCount() {
    var realPageCount = this.getRealPageCount(); 
    return realPageCount == 0 ? 1 : realPageCount;
  }

  private getTotalItemCount(): number {
    return this.alignedBankItems.filter(x => x != null).length;
  }
}
