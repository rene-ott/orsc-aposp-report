import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiPaths } from '../ApiPaths';
import { AuthResult } from '../models/auth-result.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) {
  }

  isValidKey(key: string): Observable<boolean> {
    return this.httpClient.post<AuthResult>(ApiPaths.Authentication, { apiKey: key })
      .pipe(map(x => x.isValid))
  }
}
