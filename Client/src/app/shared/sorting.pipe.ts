import { Pipe, PipeTransform } from '@angular/core';
import { IItem } from '../shared/item';

@Pipe({
  name: 'sorting'
})
export class SortingPipe implements PipeTransform {

  transform(items: IItem[], category = ''): any {

    return items.filter(item => item.category === category);
  }

}
