import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  setItem(key: string, value: string) {
    localStorage.setItem(key, value);
  }

  removeItem(key: string) {
    localStorage.removeItem(key);
  }

  getItem(key: string): string | null {
    return localStorage.getItem(key);
  }

  setJsonItem<T>(key: string, value: T) {
    this.setItem(key, JSON.stringify(value));
  }

  getJsonItem<T>(key: string): T | null {
    var value = this.getItem(key);
    return value != null ? JSON.parse(value) as T : null;
  }
}