import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BankReport } from '../models/bank-report.model';
import { ApiPaths } from '../../../shared/api-paths';

@Injectable()
export class BankReportService {
  constructor(private http: HttpClient) {
  }

  getBankReportItems(): Observable<BankReport> {
    return this.http.get<BankReport>(ApiPaths.BankReport);
  }
}