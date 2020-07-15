import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {
  AuthGuard as AuthGuard
} from '../auth/auth.guard';
import { ItemsComponent } from './items/items.component';
import {RouterModule, Routes} from '@angular/router';
import {ItemCreateComponent} from './item-create/item-create.component';
import {ItemDetailsComponent} from './item-details/item-details.component';

const routes: Routes = [
  { path: '', component: ItemsComponent },
  { path: 'create', component: ItemCreateComponent, canActivate: [AuthGuard] },
  { path: ':id', component: ItemDetailsComponent },
];


@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ItemsRoutingModule { }
