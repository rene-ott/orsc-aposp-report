import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class LocalStorageService {

  public setItem<T>(key: string, value: T) {
    // TODO: Add failsafe try catch if not JSON object.
    localStorage.setItem(key, JSON.stringify(value));
  }

  // TODO: Rename
  public getItem<T>(key: string): T | null {
      var value = localStorage.getItem(key);
      if (value == null) {
        return null;
      }

    return JSON.parse(value) as T
  }
}