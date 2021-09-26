import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of, Observable, throwError } from 'rxjs';
import { AccountReport } from './account-report.model';
import * as accountReports from '../../data/accountReports.json'; 

@Injectable({
  providedIn: 'root',
})
export class AccountReportService {

    constructor(private http: HttpClient) {
    }

  getAccountReports(): Observable<AccountReport[]> {
    //return this.http.get<AccountReport[]>("http://localhost:5000/api/report/account");

    return of(JSON.parse(JSON.stringify(accountReports)) as AccountReport[]);
  }
}