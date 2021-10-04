import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BankReport } from '../models/bank-report.model';
import { ApiPaths } from '../../../shared/ApiPaths';

@Injectable({
  providedIn: 'root',
})
export class BankReportService {
  constructor(private http: HttpClient) {
  }

  getBankReportItems(): Observable<BankReport> {
    return this.http.get<BankReport>(ApiPaths.BankReport);
  }
}