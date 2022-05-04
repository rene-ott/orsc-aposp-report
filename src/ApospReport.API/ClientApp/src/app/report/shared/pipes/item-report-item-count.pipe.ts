import { Pipe, PipeTransform } from '@angular/core';
import { ItemReportItem } from '../../item-report/models/item-report-item.model';
import { ItemReportVisibility } from '../constants/item-report-count-visibility.enum';

@Pipe({
  name: 'itemReportItemCount'
})
export class ItemReportItemCountPipe implements PipeTransform {
  transform(value: ItemReportItem | null, currentVisibility: ItemReportVisibility): any {
    var result;
    if (value == null) {
      return "";
    }
    
    if (currentVisibility === ItemReportVisibility.All) {
      result = value.count;
    } else if (currentVisibility === ItemReportVisibility.Inventory) {
      result = value.inventoryCount;
    } else {
      result = value.bankCount;
    }

    if (result === 0) {
      return "";
    }

    result = result.toLocaleString('en-US');

    if (value.isStackable) {
      result = `[${result}]`
    }

    return result;
  }
}