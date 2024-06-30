import { Component, ViewChild, ElementRef, Renderer2 } from '@angular/core';
import { NgForm } from '@angular/forms';
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
  constructor(public service: SerialDetailService, private render: Renderer2) {
    
  }

  openModal() {
    const modal = new bootstrap.Modal(this.errorModal.nativeElement);
    modal.show();
  }

  onSubmit(form:NgForm) {
    this.service.validSerial = false;
    this.service.invalidSerial = null;
    // this.service.getSerialDetail()
    if (this.service.validSerial == false) {
      this.openModal();
    }
  }
}
