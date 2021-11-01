import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { AccountReportService } from './services/account-report.service';
import { AccountReport } from './models/account-report.model';
import { AccountReportSkill } from './models/account-report-skill.model';

@Component({
  selector: 'app-account-report',
  templateUrl: './account-report.component.html',
  styleUrls: ['./account-report.component.scss']
})
export class AccountReportComponent implements OnInit {
  
  constructor(
    private accountReportService: AccountReportService) {
  }

  displayedColumns: string[] = ['username', /* 'skills', 'inventory', */ 'bank', 'actions'];
  dataSource = new MatTableDataSource<AccountReport>();;

  ngOnInit() {
    this.accountReportService.getAccountReports().subscribe(x => {
      this.dataSource.data = x;
    });
  }

  removeUser(index: number, username: string) {
    this.accountReportService.deleteUser(username).subscribe(_ => {
      this.dataSource.data.splice(index, 1);
      this.dataSource._updateChangeSubscription();
    });
  }
}
