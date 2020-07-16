import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {
  AuthGuard as AuthGuard
} from '../auth/auth.guard';
import { ItemListComponent } from './item-list/item-list.component';
import {RouterModule, Routes} from '@angular/router';
import {ItemCreateComponent} from './item-create/item-create.component';
import {ItemDetailsComponent} from './item-details/item-details.component';

const routes: Routes = [
  { path: '', component: ItemListComponent },
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
