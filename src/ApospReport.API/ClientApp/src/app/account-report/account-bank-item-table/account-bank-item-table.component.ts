import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';

@Component({
  selector: 'app-account-bank-item-table',
  templateUrl: './account-bank-item-table.component.html',
  styleUrls: ['./account-bank-item-table.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AccountBankItemTableComponent implements OnInit {
  
  private readonly MAX_PAGE_COUNT = 4;
  private readonly PAGE_SIZE = 16;

  currentPageIndex = 0;
  pageCount = 1
  currentPageItems:any[] = Array.from({length: this.PAGE_SIZE}, () => null) 

  constructor() { 
  }

  openPage(pageIndex: number) {
    this.currentPageIndex = pageIndex
    this.currentPageItems = this.getPageItems();
    console.log(this.currentPageItems)
  }

  ngOnInit(): void {
    this.pageCount = this.getPageCount();
    this.currentPageItems = this.getPageItems();
  }

  private getPageItems(): any[] {
    var firstItemIndexOnPage = this.currentPageIndex * this.PAGE_SIZE;
    var lastItemIndexOnPage = firstItemIndexOnPage + (this.isLastPage() ? this.getLastPageItemCount() : this.PAGE_SIZE)
    return this.items.slice(firstItemIndexOnPage, lastItemIndexOnPage)
  }

  private isLastPage() {
    return this.currentPageIndex == this.MAX_PAGE_COUNT - 1;
  }

  private getLastPageItemCount() {
    return this.getTotalItemCount() - (this.getPageCount() * this.PAGE_SIZE)
  }

  private getPageCount(): number {
    return Math.ceil(this.getTotalItemCount() / this.PAGE_SIZE)
  }

  private getTotalItemCount(): number {
    return this.items.filter(x => x != null).length;
  }

  items = [
    {
      "Id": 1,
      "Name": "eu",
      "Count": 10
    },
    {
      "Id": 2,
      "Name": "officidda",
      "Count": 27
    },
    {
      "Id": 3,
      "Name": "iddd",
      "Count": 13
    },
    {
      "Id": 4,
      "Name": "nulfdsala",
      "Count": 6
    },
    {
      "Id": 5,
      "Name": "anfdsaim",
      "Count": 4
    },
    {
      "Id": 6,
      "Name": "eufda",
      "Count": 29
    },
    {
      "Id": 7,
      "Name": "dofdas",
      "Count": 27
    },
    {
      "Id": 8,
      "Name": "magadsna",
      "Count": 17
    },
    {
      "Id": 9,
      "Name": "mafadsgna",
      "Count": 26
    },
    {
      "Id": 10,
      "Name": "lagfbore",
      "Count": 25
    },
    {
      "Id": 11,
      "Name": "tvxczempor",
      "Count": 9
    },
    {
      "Id": 12,
      "Name": "esvxzt",
      "Count": 30
    },
    {
      "Id": 13,
      "Name": "excefdsapteur",
      "Count": 5
    },
    {
      "Id": 14,
      "Name": "evfdst",
      "Count": 24
    },
    {
      "Id": 15,
      "Name": "Lorgfdsem",
      "Count": 22
    },
    {
      "Id": 16,
      "Name": "adiadfapisicing",
      "Count": 1
    },
    {
      "Id": 17,
      "Name": "labgfaoris",
      "Count": 8
    },
    {
      "Id": 18,
      "Name": "dugfdsis",
      "Count": 15
    },
    {
      "Id": 19,
      "Name": "adipafdsisicing",
      "Count": 28
    },
    {
      "Id": 20,
      "Name": "migfadsnim",
      "Count": 23
    },
    {
      "Id": 21,
      "Name": "esadsft",
      "Count": 19
    },
    {
      "Id": 22,
      "Name": "nosgfsdatrud",
      "Count": 4
    },
    {
      "Id": 23,
      "Name": "congfdssectetur",
      "Count": 9
    },
    {
      "Id": 24,
      "Name": "sigfadt",
      "Count": 8
    },
    {
      "Id": 25,
      "Name": "venfdasiam",
      "Count": 19
    },
    {
      "Id": 26,
      "Name": "endfsaim",
      "Count": 22
    },
    {
      "Id": 27,
      "Name": "ullafdsamco",
      "Count": 4
    },
    {
      "Id": 28,
      "Name": "qussi",
      "Count": 7
    },
    {
      "Id": 29,
      "Name": "fugissat",
      "Count": 7
    },
    {
      "Id": 30,
      "Name": "aaamet",
      "Count": 26
    },
    {
      "Id": 31,
      "Name": "reaaprehenderit",
      "Count": 9
    },
    {
      "Id": 32,
      "Name": "marewgna",
      "Count": 10
    },
    {
      "Id": 33,
      "Name": "essfdadse",
      "Count": 10
    },
    {
      "Id": 34,
      "Name": "edfsadfsse",
      "Count": 3
    },
    {
      "Id": 35,
      "Name": "esgfgdgse",
      "Count": 25
    },
    {
      "Id": 36,
      "Name": "exhg",
      "Count": 14
    },
    {
      "Id": 37,
      "Name": "incihgfddidunt",
      "Count": 29
    },
    {
      "Id": 38,
      "Name": "euhgfh",
      "Count": 13
    },
    {
      "Id": 39,
      "Name": "nisihgfdh",
      "Count": 27
    },
    {
      "Id": 40,
      "Name": "consequathgfd",
      "Count": 19
    },
    null,
    null,
    null,
    null,
    null,
    null,
    null,
  ]
}
