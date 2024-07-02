import { Component, OnInit, ViewChild, ElementRef, Renderer2 } from '@angular/core';
import { ProductDetailService } from '../shared/product-detail.service';
import { NgForm } from '@angular/forms';
import { ProductOwnerService } from '../shared/product-owner.service';
import { ToastrService } from 'ngx-toastr';

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

  constructor(
    public detailService: ProductDetailService, 
    public ownerService: ProductOwnerService, 
    private toastr:ToastrService,
    private renderer: Renderer2) {

  }

  ngOnInit(): void {
    this.detailService.getAllProducts();
  }

  openModal() {
    const modal = new bootstrap.Modal(this.exampleModal.nativeElement);
    modal.show();
  }

  selectProductDetailId(id: number): void {
    console.log("id" + id)
    this.selectedProductDetailId = id;
  }

  purchaseProduct(form: NgForm) {
    console.log("yo" + form)
    console.log(this.selectedProductDetailId)
    this.toastr.success('Purchased successfully', 'Product Purchase')
    this.ownerService.purchaseProduct(this.selectedProductDetailId)
    .subscribe({
      next: res => {
        console.log(res)
      },
      error: err => {
        this.openModal()
      }
    })
  }

}
