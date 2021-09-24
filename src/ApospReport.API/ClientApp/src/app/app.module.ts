import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AccountReportComponent } from './account-report/account-report.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { AppRoutingModule } from './app-routing.module';
import { AccountBankItemTableComponent } from './account-report/account-bank-item-table/account-bank-item-table.component';


@NgModule({
  declarations: [	
    AppComponent,
    AccountReportComponent,
    AccountBankItemTableComponent
   ],
  imports: [
    BrowserModule,
    MatTabsModule,
    MatButtonModule,
    MatTableModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  exports: [
    AccountBankItemTableComponent
  ]
})
export class AppModule { }
