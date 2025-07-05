import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit {
  cartItems: any[] = [];

  constructor(private cartService: CartService) {}

  ngOnInit(): void {
   this.getCartItems();
  }

 getCartItems(): void {
  this.cartService.getCart().subscribe(data => {
    this.cartItems = data;
  });
  }

  get subtotal() {
    return this.cartItems.reduce((sum, item) => sum + (item.price * item.quantity), 0);
  }
  
  get tax() {
    return this.subtotal * 0.1;
  }
  
  get total() {
    return this.subtotal + this.tax;
  }

  onSubmit(form: any) {
    if (form.valid) {
      console.log('Form submitted:', this.cartItems);
    }
  }
}
