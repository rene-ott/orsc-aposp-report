import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AccountReportComponent } from './account-report/account-report.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AccountBankItemTableComponent } from './account-report/account-bank-item-table/account-bank-item-table.component';
import { ItemImageService } from './shared/services/item-image.service';
import { ItemSlotImageComponent } from './shared/components/item-slot-image/item-slot-image.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatCardModule} from '@angular/material/card';
import { BankReportComponent } from './bank-report/bank-report.component';


@NgModule({
  declarations: [	
    AppComponent,
    AccountReportComponent,
    BankReportComponent,
    AccountBankItemTableComponent,
    ItemSlotImageComponent
   ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    MatTabsModule,
    MatButtonModule,
    MatTableModule,
    AppRoutingModule,
    HttpClientModule,
    MatCardModule,
  ],
  providers: [ItemImageService],
  bootstrap: [AppComponent],
  exports: [
    AccountBankItemTableComponent,
    ItemSlotImageComponent,
  ]
})
export class AppModule { }
