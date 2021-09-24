import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AccountReportComponent } from './account-report/account-report.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { AppRoutingModule } from './app-routing.module';


@NgModule({
  declarations: [	
    AppComponent,
    AccountReportComponent
   ],
  imports: [
    BrowserModule,
    MatTabsModule,
    MatTableModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
