import { Component, OnInit } from '@angular/core';
import { ProductOwnerService } from '../shared/product-owner.service';
import { ActivatedRoute } from '@angular/router';
import { ProductDetailService } from '../shared/product-detail.service';

@Component({
  selector: 'app-product-view-single',
  templateUrl: './product-view-single.component.html',
  styles: [
  ]
})
export class ProductViewSingleComponent implements OnInit {

  id!: string;

  constructor(
    public service: ProductOwnerService, 
    public productService: ProductDetailService,
    private route: ActivatedRoute,) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id') || '';
    this.getProductFullDetails(this.id);
  }

  getProductFullDetails(id: string) {
    this.productService.getFullProductInfo(this.id)
  }
}
