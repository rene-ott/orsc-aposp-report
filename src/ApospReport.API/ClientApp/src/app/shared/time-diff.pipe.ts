import { Pipe, PipeTransform } from '@angular/core';
import { min } from 'lodash';

@Pipe({ name: 'timeDiff' })
export class TimeDiffPipe implements PipeTransform {
    transform(value: string): string {

        const currentTimestamp = new Date();
        const inputTimestamp = new Date(value);

        var difference = currentTimestamp.getTime() - inputTimestamp.getTime();
        var resultInMinutes = Math.round(difference / 60000);

        var resultInHours = Math.floor(resultInMinutes / 60);
        var mins = resultInMinutes % 60;

        if (resultInHours == 0) {
            return `${mins} min ago`
        }

        return `${resultInHours} hour, ${mins} min ago`;
    }
}