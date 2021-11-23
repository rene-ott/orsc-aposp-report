import { Pipe, PipeTransform } from '@angular/core';
import { DecimalPipe } from '@angular/common'

@Pipe({
  name: 'naNumber'
})
export class NaNumberPipe extends DecimalPipe implements PipeTransform {
  transform(value: any, args?: any, digitsInfo?: any, numberPrefix?: any): any {

    if (value == null) {
        return "N/A";
    }

    let result;
    result = super.transform(value, args, digitsInfo);

    if (numberPrefix) {
        return result + numberPrefix;
    }
    return result;
  }
}