import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountReport } from './../models/account-report.model';
import { ApiPaths } from '../../../shared/api-paths';

@Injectable()
export class AccountReportService {

  constructor(private http: HttpClient) {
  }

  getAccountReports(): Observable<AccountReport[]> {
    return this.http.get<AccountReport[]>(ApiPaths.AccountReport);
  }

  deleteUser(username: string): Observable<unknown> {
    return this.http.delete(`${ApiPaths.AccountReport}/${username}`);
  }
}