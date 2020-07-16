import { Component, OnInit } from '@angular/core';
import { IItem } from '../../shared/item';
import {ItemsService} from '../../shared/services/items.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-items',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.scss']
})
export class ItemListComponent implements OnInit {
  items: IItem[];
  id: string;
  category: null;

  constructor(private itemsService: ItemsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getItems();
  }

  getItems() {
    this.itemsService.getItems();
  }
}
