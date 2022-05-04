import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../shared/auth-guard';
import { AccountReportComponent } from './account-report/account-report.component';
import { ItemReportComponent } from './item-report/item-report.component';
import { ReportComponent } from './report.component';

const routes: Routes = [
  {
    path: 'report', component: ReportComponent, canActivate: [AuthGuard], children: [
      { path: '', redirectTo: 'account', pathMatch: 'full' },
      { path: 'account', component: AccountReportComponent },
      { path: 'item', component: ItemReportComponent }
    ],
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
