import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountReportComponent } from './account-report/account-report.component';
import { BankReportComponent } from './bank/bank-report.component';
import { ReportComponent } from './report.component';

const routes: Routes = [
  {
    path: 'report', component: ReportComponent, children: [
      { path: 'account', component: AccountReportComponent },
      { path: 'bank', component: BankReportComponent }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ReportRoutingModule { };
