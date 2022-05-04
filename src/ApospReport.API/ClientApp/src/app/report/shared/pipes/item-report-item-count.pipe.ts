import { Pipe, PipeTransform } from '@angular/core';
import { DecimalPipe } from '@angular/common'
import { ItemReportItem } from '../../item-report/models/item-report-item.model';

@Pipe({
  name: 'itemReportItemCount'
})
export class ItemReportItemCountPipe implements PipeTransform {
  transform(value: ItemReportItem, currentVisibility: ItemReportVisibility): any {
  }
}