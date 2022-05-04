import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ItemReport } from '../models/item-report.model';
import { ApiPaths } from '../../../shared/api-paths';

@Injectable()
export class ItemReportService {
  constructor(private http: HttpClient) {
  }

  getItemReport(): Observable<ItemReport> {
    return this.http.get<ItemReport>(ApiPaths.ItemReport);
  }
}