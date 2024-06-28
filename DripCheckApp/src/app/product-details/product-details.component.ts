import { Component, OnInit, ViewChild, ElementRef, Renderer2 } from '@angular/core';
import { ProductDetailService } from '../shared/product-detail.service';
import { NgForm } from '@angular/forms';
import { ProductOwnerService } from '../shared/product-owner.service';

declare var bootstrap: any;

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styles: [
  ]
})
export class ProductDetailsComponent implements OnInit {

  @ViewChild('exampleModal') exampleModal!: ElementRef;
  selectedProductDetailId: number = 0;

  constructor(public detailService: ProductDetailService, public ownerService: ProductOwnerService, private renderer: Renderer2) {

  }

  ngOnInit(): void {
    this.detailService.getAllProducts();
  }

  openModal() {
    const modal = new bootstrap.Modal(this.exampleModal.nativeElement);
    modal.show();
  }

  purchaseProduct(form: NgForm) {
    this.ownerService.purchaseProduct(this.selectedProductDetailId)
    .subscribe({
      next: res => {
        console.log(res)
      },
      error: err => {
        console.log(err)
      }
    })
  }

}
