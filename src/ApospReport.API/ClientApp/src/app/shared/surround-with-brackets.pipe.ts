import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'surroundWithBrackets' })
export class SurroundWithBracketsPipe implements PipeTransform {
    transform(value: any): string {
        return value == null ? "" : `[${value}]`;
    }
}