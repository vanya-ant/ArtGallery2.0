import { Injectable } from '@angular/core';
import { IItem } from '../item';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {
  item: IItem;

  constructor() { }

  async createItem(item: IItem) {

  }

  async getAllItems() {

  }
}
