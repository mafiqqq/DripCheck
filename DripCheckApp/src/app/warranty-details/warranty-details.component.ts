import { Component, OnInit } from '@angular/core';
import { WarrantyDetailService } from '../shared/warranty-detail.service';
import { WarrantyDetail } from '../shared/warranty-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-warranty-details',
  templateUrl: './warranty-details.component.html',
  styles: [
  ]
})
export class WarrantyDetailsComponent implements OnInit {
  constructor(public service: WarrantyDetailService, private toastr:ToastrService) {

  }
  
  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord: WarrantyDetail) {
    this.service.formData = Object.assign({},selectedRecord);
  }

  deleteWarranty(id:number) {
    if(confirm('Are you sure to delete this record?')) {
      this.service.deleteWarrantyDetail(id)
      .subscribe({
        next: res => {
          this.service.list = res as WarrantyDetail[]
          this.toastr.error('Deleted warranty successfully', 'Warranty Detail')
        },
        error: err => {console.log(err)}
      })
    }
  }

}
