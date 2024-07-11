import { Component, OnInit } from '@angular/core';
import { ProductOwnerService } from '../shared/product-owner.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-my-product',
  templateUrl: './my-product.component.html',
  styles: [
  ]
})
export class MyProductComponent implements OnInit {
  
  id!: string;
  constructor(
    public service: ProductOwnerService,
    private route: ActivatedRoute,) {}
  
  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id') || '';
    console.log(this.id)
    this.displayInfo();
  }

  displayInfo() {
    this.service.getFullProduct(this.id);
  }

}
