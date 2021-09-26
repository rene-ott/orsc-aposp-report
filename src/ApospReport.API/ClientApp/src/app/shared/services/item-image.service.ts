import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of, Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { ItemImage } from '../models/item-image.model';
import { LocalStorageService } from './local-storage.service';

@Injectable()
export class ItemImageService {

    private readonly ITEM_IMAGES_KEY = "ITEM_IMAGES_KEY"
    constructor(private http: HttpClient,
        private localStorageService: LocalStorageService) { 
    }

  downloadItemImages(): Observable<ItemImage[]> {
    return this.http
    .get<ItemImage[]>("http://localhost:5000/api/report/item-images")
    .pipe(map(x => {
        this.localStorageService.setItem(this.ITEM_IMAGES_KEY, x);
        return x;
    }));
  }

  getItemImages() : ItemImage[] {
      var cachedItemImages = this.localStorageService.getItem<ItemImage[]>(this.ITEM_IMAGES_KEY);
      return cachedItemImages!!;
  }
}