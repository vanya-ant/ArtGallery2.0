import { Pipe, PipeTransform } from '@angular/core';
import { IItem } from '../shared/item';

@Pipe({
  name: 'sorting'
})
export class SortingPipe implements PipeTransform {

  transform(products: IItem[], category = ''): any {

    return products.filter(item => item.category === category);
  }

}
