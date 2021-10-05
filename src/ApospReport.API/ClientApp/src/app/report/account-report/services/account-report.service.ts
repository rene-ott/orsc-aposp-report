import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountReport } from './../models/account-report.model';
import { ApiPaths } from '../../../shared/ApiPaths';

@Injectable({
  providedIn: 'root',
})
export class AccountReportService {

  constructor(private http: HttpClient) {
  }

  getAccountReports(): Observable<AccountReport[]> {
    return this.http.get<AccountReport[]>(ApiPaths.AccountReport);
  }
}