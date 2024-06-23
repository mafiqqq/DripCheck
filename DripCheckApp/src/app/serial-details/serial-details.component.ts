import { Component } from '@angular/core';
import { SerialDetailService } from '../shared/serial-detail.service';
import { SerialDetail } from '../shared/serial-detail.model';

@Component({
  selector: 'app-serial-details',
  templateUrl: './serial-details.component.html',
  styles: [
  ]
})
export class SerialDetailsComponent {
  
  constructor(public service: SerialDetailService) {

  }


}
