import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private baseUrl = 'http://localhost:5066/api/cart';

  constructor(private http: HttpClient) {}

  addToCart(productId: number, quantity: number) {
    return this.http.post(`${this.baseUrl}/add`, {
      productId,
      quantity
    });
  }

  getCart() {
    return this.http.get<any[]>(`${this.baseUrl}`);
  }
}