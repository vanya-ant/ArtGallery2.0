import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import {ReactiveFormsModule} from '@angular/forms';



@NgModule({
  declarations: [ShoppingCartComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class OrdersModule { }
