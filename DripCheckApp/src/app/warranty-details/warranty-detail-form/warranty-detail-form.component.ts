import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { WarrantyDetail } from 'src/app/shared/warranty-detail.model';
import { WarrantyDetailService } from 'src/app/shared/warranty-detail.service';

@Component({
  selector: 'app-warranty-detail-form',
  templateUrl: './warranty-detail-form.component.html',
  styles: [
  ]
})
export class WarrantyDetailFormComponent {
  constructor(public service: WarrantyDetailService, private toastr:ToastrService) {

  }

  // onSubmit(form:NgForm) {
  //   this.service.formSubmitted = true
  //   if(form.valid){
  //     if (this.service.formData.warrantyDetailId == 0) {
  //       this.insertRecord(form)
  //     }
  //     else {
  //       this.updateRecord(form)
  //     }
  //   }
  // }

  // insertRecord(form: NgForm) {
  //   this.service.postWarrantyDetail()
  //   .subscribe({
  //     next: res => {
  //       this.service.list = res as WarrantyDetail[]
  //       this.service.resetForm(form)
  //       this.toastr.success('Registered successfully', 'Warranty Registration')
  //     },
  //     error: err => {
  //       console.log(err)
  //     }
  //   })
  // }

  // updateRecord(form: NgForm) {
  //   this.service.putWarrantyDetail()
  //   .subscribe({
  //     next: res => {
  //       this.service.list = res as WarrantyDetail[]
  //       this.service.resetForm(form)
  //       this.toastr.info('Updated successfully', 'Warranty Extended')
  //     },
  //     error: err => {
  //       console.log(err)
  //     }
  //   })
  // }

}
