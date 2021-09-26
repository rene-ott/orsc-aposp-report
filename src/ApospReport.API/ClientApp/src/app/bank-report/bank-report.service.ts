import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of, Observable, throwError } from 'rxjs';
import * as bankReports from '../../data/bankReports.json'; 
import { BankReportItem } from './bank-report-item.model';
import * as _ from 'lodash'

@Injectable({
  providedIn: 'root',
})
export class BankReportService {

    constructor(private http: HttpClient) {
    }

  getBankReportItems(): Observable<BankReportItem[]> {
    //return this.http.get<AccountReport[]>("http://localhost:5000/api/report/account");
    var bankIems = JSON.parse(JSON.stringify(bankReports)) as BankReportItem[]
    return of(_.map(bankIems, x => x));
  }
}