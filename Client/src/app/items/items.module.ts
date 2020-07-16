import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemListComponent } from './item-list/item-list.component';
import { ItemDetailsComponent } from './item-details/item-details.component';
import { ItemCreateComponent } from './item-create/item-create.component';
import {ReactiveFormsModule} from '@angular/forms';


@NgModule({
  declarations: [ItemListComponent, ItemDetailsComponent, ItemCreateComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
    ]
})
export class ItemsModule { }
