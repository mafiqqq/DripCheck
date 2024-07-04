import { Component, OnInit } from '@angular/core';
import { WarrantyDetailService } from '../shared/warranty-detail.service';
import { WarrantyDetail } from '../shared/warranty-detail.model';
import { ToastrService } from 'ngx-toastr';
import { ProductOwnerService } from '../shared/product-owner.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-warranty-details',
  templateUrl: './warranty-details.component.html',
  styles: [
  ]
})
export class WarrantyDetailsComponent implements OnInit {
  
  warrantyList: WarrantyDetail | undefined;
  constructor(
    public service: WarrantyDetailService, 
    public serviceOwner: ProductOwnerService,
    private toastr:ToastrService,
    private router: Router) {

  }
  
  ngOnInit(): void {
    this.serviceOwner.getWarrantyList();
  }

  populateForm(selectedRecord: WarrantyDetail) {
    this.service.formData = Object.assign({},selectedRecord);
  }

  extendWarranty(id: number) {
    this.service.extendWarrantyDetail(id)
    .subscribe({
      next: res => {
        console.log(res)
        this.serviceOwner.getWarrantyList()
        this.toastr.success('Updated successfully', 'Warranty Update')
      },
      error: err => {
        console.log(err)
      }
    })
  }

  viewDetails(id: number) {
    this.serviceOwner.viewProductDetail(id)
    .subscribe({
      next: (res) => {
        console.log(res)
        this.warrantyList = res as WarrantyDetail
        console.log(this.warrantyList.productOwnerId)
        this.router.navigate(['view-product/' + this.warrantyList.productOwnerId])
      },
      error: err => {
        console.log(err)
      }
    })
  }

  // deleteWarranty(id:number) {
  //   if(confirm('Are you sure to delete this record?')) {
  //     this.service.deleteWarrantyDetail(id)
  //     .subscribe({
  //       next: res => {
  //         this.service.list = res as WarrantyDetail[]
  //         this.toastr.error('Deleted warranty successfully', 'Warranty Detail')
  //       },
  //       error: err => {console.log(err)}
  //     })
  //   }
  // }

}
