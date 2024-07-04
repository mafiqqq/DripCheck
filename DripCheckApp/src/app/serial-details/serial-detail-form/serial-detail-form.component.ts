import { Component, ViewChild, ElementRef, Renderer2 } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductOwnerService } from 'src/app/shared/product-owner.service';
import { SerialDetail } from 'src/app/shared/serial-detail.model';
import { SerialDetailService } from 'src/app/shared/serial-detail.service';

declare var bootstrap: any;

@Component({
  selector: 'app-serial-detail-form',
  templateUrl: './serial-detail-form.component.html',
  styles: [
  ]
})
export class SerialDetailFormComponent {
  
  serialDetails: SerialDetail[] = [];
  @ViewChild('errorModal') errorModal!: ElementRef;
  constructor(
    public service: SerialDetailService, 
    public serviceOwner: ProductOwnerService,
    private render: Renderer2,
    private router: Router) {
    
  }

  openModal() {
    const modal = new bootstrap.Modal(this.errorModal.nativeElement);
    modal.show();
  }

  onSubmit(form:NgForm) {
    this.serviceOwner.validSerial = false;
    this.serviceOwner.invalidSerial = null;
    // console.log(this.serialNumber)
    this.serviceOwner.checkSerialNumber()
    .subscribe({
      next: res => {
        this.serviceOwner.validSerial = true
        console.log(this.serviceOwner.validSerial+'cc')
        console.log(res)
        this.checkRedirect(res);
      },
      error: err => {
        this.checkRedirect(err);
        console.log(err)
      }
    })
    console.log(this.serviceOwner.validSerial+'pp')
  }

  checkRedirect(res: any) {
    console.log(this.serviceOwner.validSerial+'zz')
    if (this.serviceOwner.validSerial == false) {
      this.openModal();
    } else {
      console.log("ya");  
      this.router.navigate(['view-product/' + res])
    }
  }
}
