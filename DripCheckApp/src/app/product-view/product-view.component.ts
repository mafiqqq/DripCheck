import { Component } from '@angular/core';
import { ProductOwnerService } from '../shared/product-owner.service';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styles: [
  ]
})
export class ProductViewComponent {

  
  constructor(public service: ProductOwnerService) {

  }
}
