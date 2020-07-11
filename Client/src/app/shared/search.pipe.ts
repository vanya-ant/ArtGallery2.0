import { Pipe, PipeTransform } from '@angular/core';
import {IItem} from './item';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(items: IItem[], itemName = ''): any {
    if (!itemName.trim()) {
      return items;
    }
    return items.filter(item => item.name.toLowerCase().includes(itemName.toLowerCase()));
  }
}
