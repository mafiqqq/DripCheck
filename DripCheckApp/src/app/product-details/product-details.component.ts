import { Component, OnInit } from '@angular/core';
import { ProductDetailService } from '../shared/product-detail.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styles: [
  ]
})
export class ProductDetailsComponent implements OnInit {
  constructor(public service: ProductDetailService) {

  }

  ngOnInit(): void {
    this.service.getAllProducts();
  }

  openModal() {
    const modalDiv = document.getElementById('buyModal');
    console.log(modalDiv);
    if (modalDiv != null) {
      modalDiv.style.display = 'block';
    }
  }

  closeModal() {
    const modalDiv = document.getElementById('buyModal');
    if (modalDiv != null) {
      modalDiv.style.display = 'none';
    }
  }
}
