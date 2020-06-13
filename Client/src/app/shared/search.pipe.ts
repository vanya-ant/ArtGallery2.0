import { Pipe, PipeTransform } from '@angular/core';
import {IItem} from './item';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(products: IItem[], itemName = ''): any {
    if (!itemName.trim()) {
      return products;
    }
    return products.filter(item => item.name.toLowerCase().includes(itemName.toLowerCase()));
  }
}
