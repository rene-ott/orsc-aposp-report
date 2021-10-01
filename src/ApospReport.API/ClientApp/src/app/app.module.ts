import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthService } from './shared/services/auth.service';
import { CookieService } from 'ngx-cookie-service';
import { ReportModule } from './report/report.module';
import { LoginModule } from './login/login.module';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    LoginModule,
    ReportModule,
    AppRoutingModule
  ],
  providers: [AuthService, CookieService],
  bootstrap: [AppComponent],
  exports: []
})
export class AppModule { }
