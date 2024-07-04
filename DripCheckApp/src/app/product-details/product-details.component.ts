import { Component, OnInit, ViewChild, ElementRef, Renderer2 } from '@angular/core';
import { ProductDetailService } from '../shared/product-detail.service';
import { NgForm } from '@angular/forms';
import { ProductOwnerService } from '../shared/product-owner.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ProductOwner } from '../shared/product-owner.model';

declare var bootstrap: any;
declare var $: any;

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
    private renderer: Renderer2,
    private router: Router) {

  }

  ngOnInit(): void {
    this.detailService.getAllProducts();
  }

  openModal() {
    const modal = new bootstrap.Modal(this.exampleModal.nativeElement);
    modal.show();
  }

  closeModal() {
    const modal = new bootstrap.Modal(this.exampleModal.nativeElement)
    if (modal) {
      modal.hide();
    }
  }

  hideBackdrop() {
    const backdrop = document.querySelector('.modal-backdrop');
    backdrop?.classList.remove('fade', 'show');
  }

  selectProductDetailId(id: number): void {
    console.log("id" + id)
    this.selectedProductDetailId = id;
  }

  purchaseProduct(form: NgForm) {
    this.ownerService.purchaseProduct(this.selectedProductDetailId)
    .subscribe({
      next: res => {        
        this.toastr.success('Purchased successfully', 'Product Purchase')
        this.closeModal()
        this.router.navigate(['/view-product/'+ res ])
        console.log(res)
      },
      error: err => {
        this.openModal()
      }
    })
  }

}
