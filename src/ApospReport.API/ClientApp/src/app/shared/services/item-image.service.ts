import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ItemImage } from '../models/item-image.model';
import { LocalStorageService } from './local-storage.service';
import { ApiPaths } from '../ApiPaths';

@Injectable()
export class ItemImageService {

  private readonly ITEM_IMAGES_KEY = "ITEM_IMAGES_KEY"

  constructor(private http: HttpClient,
    private localStorageService: LocalStorageService) {
  }

  downloadItemImages(): Observable<ItemImage[]> {
    return this.http
      .get<ItemImage[]>(ApiPaths.ItemImages)

      .pipe(map(x => {
        this.localStorageService.setJsonItem(this.ITEM_IMAGES_KEY, x);
        return x;
      }));
  }

  getItemImages(): ItemImage[] {
    var cachedItemImages = this.localStorageService.getJsonItem<ItemImage[]>(this.ITEM_IMAGES_KEY);
    return cachedItemImages!!;
  }
}