import { Component, OnInit } from '@angular/core';
import { ProductOwnerService } from '../shared/product-owner.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-view-single',
  templateUrl: './product-view-single.component.html',
  styles: [
  ]
})
export class ProductViewSingleComponent implements OnInit {

  id!: string;

  constructor(public service: ProductOwnerService, private route: ActivatedRoute,) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id') || '';
    // this.refreshList();
  }

  getProductFullDetails() {
    this.service.getFullProductInfo(this.id)
  }
}
