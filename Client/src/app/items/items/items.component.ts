import { Component, OnInit } from '@angular/core';
import { IItem } from '../../shared/item';
import {ItemsService} from '../../shared/services/items.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.scss']
})
export class ItemsComponent implements OnInit {
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
