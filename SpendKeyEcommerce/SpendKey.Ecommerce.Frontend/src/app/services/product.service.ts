import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Product {
  id: number;
  name: string;
  price: number;
  availabilityQty: number;
}

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl = 'http://localhost:5066/api/products';

  constructor(private http: HttpClient) {}

  getProducts(categoryId: number): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}?categoryId=${categoryId}`);
  }
}
