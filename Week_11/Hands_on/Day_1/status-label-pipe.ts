import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'statusLabel',
})
export class StatusLabelPipe implements PipeTransform {
   public transform(isActive: boolean): string {
    return isActive ? 'Active' : 'Inactive';
  }
}
