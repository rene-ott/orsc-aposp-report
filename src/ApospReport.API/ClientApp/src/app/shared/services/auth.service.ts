import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiPaths } from '../ApiPaths';
import { AuthResult } from '../models/auth-result.model';
import { LocalStorageService } from './local-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loggedIn = new BehaviorSubject<boolean>(false);

  private AUTH_HEADER_KEY = "X-API-KEY";

  constructor(private httpClient: HttpClient, private localStorageService: LocalStorageService) {
  }

  isValidApiKey(key: string): Observable<boolean> {
    return this.httpClient.post<AuthResult>(ApiPaths.Authentication, { apiKey: key })
      .pipe(map(x => x.isValid))
  }

  isApiKeySet(): boolean {
    return this.getApiKey() != null;
  }

  getApiKey(): string {
    return this.localStorageService.getItem(this.AUTH_HEADER_KEY)!!;
  }

  setApiKey(apiKey: string) {
    this.localStorageService.setItem(this.AUTH_HEADER_KEY, apiKey);
    this.markAsLoggedIn();
  }

  removeApiKey() {
    this.localStorageService.removeItem(this.AUTH_HEADER_KEY);
    this.loggedIn.next(false);
  }

  markAsLoggedIn() {
    if (this.getApiKey() != null) {
      this.loggedIn.next(true)
    }
  }

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }
}
