import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SerialDetail } from 'src/app/shared/serial-detail.model';
import { SerialDetailService } from 'src/app/shared/serial-detail.service';

@Component({
  selector: 'app-serial-detail-form',
  templateUrl: './serial-detail-form.component.html',
  styles: [
  ]
})
export class SerialDetailFormComponent {
  
  serialDetails: SerialDetail[] = [];
  constructor(public service: SerialDetailService) {
    
  }

  onSubmit(form:NgForm) {
    this.service.validSerial = false;
    this.service.invalidSerial = null;
    this.service.getSerialDetail()
  }
}
