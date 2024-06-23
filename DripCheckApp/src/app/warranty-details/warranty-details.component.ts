import { Component, OnInit } from '@angular/core';
import { WarrantyDetailService } from '../shared/warranty-detail.service';
import { WarrantyDetail } from '../shared/warranty-detail.model';

@Component({
  selector: 'app-warranty-details',
  templateUrl: './warranty-details.component.html',
  styles: [
  ]
})
export class WarrantyDetailsComponent implements OnInit {
  constructor(public service: WarrantyDetailService) {

  }
  
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: WarrantyDetail) {
    this.service.formData = Object.assign({},selectedRecord);
  }

}
