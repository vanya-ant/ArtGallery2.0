import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ItemsService } from '../../shared/services/items.service';
import { OrdersService } from '../../shared/services/orders-service.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {

  cartItems = [];
  totalPrice = 0;
  added = '';

  form: FormGroup;
  submitted = false;

  constructor(
    private itemsService: ItemsService,
    private ordersService: OrdersService,
  ) { }

  ngOnInit(): void {
    /*this.cartItems = this.itemsService.cartItems;*/

    this.totalPrice = this.cartItems.reduce((sum, current) => {
      return sum + +current.price;
    }, 0);

    this.form = new FormGroup({
      name: new FormControl(null, Validators.required),
      phone: new FormControl(null, Validators.required),
      address: new FormControl(null, Validators.required),
      payment: new FormControl('Cash'),
    });
  }

  submit() {
    if (this.form.invalid) {
      return;
    }

    this.submitted = true;

    const order = {
      name: this.form.value.name,
      phone: this.form.value.phone,
      address: this.form.value.address,
      payment: this.form.value.payment,
      orders: this.cartItems,
      price: this.totalPrice,
      date: new Date(),
    };

/*    this.ordersService.create(order).subscribe(res => {
      this.form.reset();
      this.added = 'Delivery is framed';
      this.submitted = false;
    });*/
  }

  delete(product) {
    this.totalPrice -= +product.price;
    this.cartItems.splice(this.cartItems.indexOf(product), 1);
  }
}
