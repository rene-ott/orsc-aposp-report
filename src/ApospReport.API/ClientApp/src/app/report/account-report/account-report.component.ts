import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ItemImageService } from '../../shared/services/item-image.service';
import * as _ from 'lodash'
import { AccountReportService } from './services/account-report.service';
import { AccountReport } from './models/account-report.model';

@Component({
  selector: 'app-account-report',
  templateUrl: './account-report.component.html',
  styleUrls: ['./account-report.component.scss']
})
export class AccountReportComponent implements OnInit {

  constructor(private itemImageService: ItemImageService,
    private accountReportService: AccountReportService) {
  }

  displayedColumns: string[] = ['username', /* 'skills', 'inventory', */ 'bank'];
  dataSource = new MatTableDataSource<AccountReport>();;

  ngOnInit() {
    this.accountReportService.getAccountReports().subscribe(x => {
      this.dataSource.data = x;
      this.setBase64ImageToBankItems(x);
    });
  }

  setBase64ImageToBankItems(accountReports: AccountReport[]) {
    //TODO: in prod _map, can be replaced with array.map 
    var bankItems = _.flatten(_.map(accountReports, x => x.bankItems))
    var itemImages = this.itemImageService.getItemImages();

    bankItems.forEach(x => {
      var foundImage = itemImages.find(i => i.id == x.id);
      x.base64 = foundImage!!.data
    });
  }
}
