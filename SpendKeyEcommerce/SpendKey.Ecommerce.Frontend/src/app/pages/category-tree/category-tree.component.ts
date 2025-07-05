import { Component, OnInit } from '@angular/core';
import { Category, CategoryService } from '../../services/category.service';
import { Product, ProductService } from '../../services/product.service';
import { CartService } from '../../services/cart.service';

@Component({
  selector: 'app-category-tree',
  templateUrl: './category-tree.component.html',
  styleUrls: ['./category-tree.component.css'] 
})
export class CategoryTreeComponent implements OnInit {
  categories: Category[] = [];
  products: Product[] = [];

  constructor(
    private categoryService: CategoryService,
    private productService: ProductService,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(data => {
      this.categories = data;
    });
  }

  loadProducts(categoryId: number) {
    this.productService.getProducts(categoryId).subscribe(data => {
      this.products = data.filter(p => p.availabilityQty > 0);
    });
  }
  
  addToCart(productId: number) {
    this.cartService.addToCart(productId, 1).subscribe(() => {
      alert('Added to cart');
    });
  }
}