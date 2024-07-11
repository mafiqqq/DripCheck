import { Component, OnInit, ViewChild, ElementRef, Renderer2 } from '@angular/core';
import { ProductDetailService } from '../shared/product-detail.service';
import { NgForm } from '@angular/forms';
import { ProductOwnerService } from '../shared/product-owner.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { ProductOwner } from '../shared/product-owner.model';
import { Auth } from '../shared/auth.model';
import { AuthService } from '../shared/auth.service';

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
  @ViewChild('viewModal') viewModal!: ElementRef;
  @ViewChild('errorModal') errorModal! : ElementRef;
  @ViewChild('outModal') outModal! : ElementRef;
  selectedProductDetailId: number = 0;
  user: string | null = null;

  constructor(
    public detailService: ProductDetailService, 
    public ownerService: ProductOwnerService,
    public authService: AuthService, 
    private toastr:ToastrService,
    private renderer: Renderer2,
    private router: Router) {

  }

  ngOnInit(): void {
    this.detailService.getAllProducts();
    this.user = this.authService.getUser();
  }

  openModal() {
    
    if (this.user) {
      const modal = new bootstrap.Modal(this.exampleModal.nativeElement);
      modal.show();
    } else {
      const errModal = new bootstrap.Modal(this.errorModal.nativeElement);
      errModal.show()
      console.log('Please login')
    }
  }

  openOutModal() {
    const modal = new bootstrap.Modal(this.outModal.nativeElement);
    modal.show();
  }

  openViewDetails() {
    const modal = new bootstrap.Modal(this.viewModal.nativeElement)
    modal.show();
  }

  closeModal() {
    const modal = new bootstrap.Modal(this.exampleModal.nativeElement)
    if (modal) {
      modal.hide();
    }
  }

  closeErrorModal() {
    const modalElement = document.getElementById('errorModal');
    const modalInstance = bootstrap.Modal.getInstance(modalElement);
    modalInstance.hide();
  }

  closeOutModal() {
    const modalElementO = document.getElementById('outModal');
    const modalInstanceO = bootstrap.Modal.getInstance(modalElementO);
    modalInstanceO.hide();
  }

  hideBackdrop() {
    const backdrop = document.querySelector('.modal-backdrop');
    backdrop?.classList.remove('fade', 'show');
  }

  selectProductDetailId(id: number): void {
    this.selectedProductDetailId = id;
  }

  routeToLogin() {
    try {
      this.closeErrorModal();
    } catch (err) { 
      this.openModal();
    }

    this.router.navigate(['/login'])
  }

  purchaseProduct(form: NgForm) {
    this.ownerService.purchaseProduct(this.selectedProductDetailId)
    .subscribe({
      next: res => {        
        this.toastr.success('Purchased successfully', 'Product Purchase')
        this.closeModal()
        this.router.navigate(['/view-product/'+ res ])
      },
      error: err => {
        this.closeModal()
        this.openOutModal()
        console.log('yes er')
      }
    })
  }

  navigateToPage(id: number) {
    this.router.navigate(['/view-product-single/' + id.toString()])
  }

}
