import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { WarrantyDetailService } from '../shared/warranty-detail.service';
import { WarrantyDetail } from '../shared/warranty-detail.model';
import { ToastrService } from 'ngx-toastr';
import { ProductOwnerService } from '../shared/product-owner.service';
import { Router } from '@angular/router';
import { Modal } from 'bootstrap';

declare var bootstrap: any;

@Component({
  selector: 'app-warranty-details',
  templateUrl: './warranty-details.component.html',
  styles: [
  ]
})
export class WarrantyDetailsComponent implements OnInit {
  
  warrantyList: WarrantyDetail | undefined;
  requestedWarrantyList: WarrantyDetail | undefined;
  modalInstance!: Modal;
  @ViewChild('warrantyModal') warrantyModal!: ElementRef;
  @ViewChild('approveModal') approveModal!: ElementRef;
  selectedDuration!: number;
  warrantyDetailId!: number;
  reqReason: string = "";
  constructor(
    public service: WarrantyDetailService, 
    public serviceOwner: ProductOwnerService,
    private toastr:ToastrService,
    private router: Router) {

  }
  
  ngOnInit(): void {
    this.serviceOwner.getWarrantyList();
    this.serviceOwner.getRequestedWarrantyList();
  }

  ngAfterViewInit() {
    this.modalInstance = new Modal(this.warrantyModal.nativeElement);
  }

  populateForm(selectedRecord: WarrantyDetail) {
    this.service.formData = Object.assign({},selectedRecord);
  }

  extendWarranty() {
    console.log(this.warrantyDetailId + '/' + this.selectedDuration)
    this.service.extendWarrantyDetailAdmin(this.warrantyDetailId, this.selectedDuration)
    .subscribe({
      next: res => {
        this.closeModal();
        this.serviceOwner.getWarrantyList()
        this.toastr.success('Updated successfully', 'Warranty Update')
        this.router.navigate(['/warranty'])
      },
      error: err => {
        console.log(err)
      }
    })
    this.closeModal();
  }

  openExtendedWarrantyModel(id: number){
    this.warrantyDetailId = id;
    const modalW = new bootstrap.Modal(this.warrantyModal.nativeElement);
    modalW.show(); 
  }

  openApprovalWarrantyModal(id: number){
    this.warrantyDetailId = id;
    const modalW = new bootstrap.Modal(this.approveModal.nativeElement);
    modalW.show(); 
  }

  closeModal() {
    // const modalW = new bootstrap.Modal(this.warrantyModal.nativeElement);
    // console.log(modalW)
    // modalW.hide();
    const modalElementWr = document.getElementById('warrantyModal');
    const modalInstanceWr = bootstrap.Modal.getInstance(modalElementWr);
    modalInstanceWr.hide();
  }

  closeApproveModal() {
    const modalW = new bootstrap.Modal(this.approveModal.nativeElement);
    modalW.hide();
  }

  selectDuration(duration: number) {
    this.selectedDuration = duration;
  }

  approveWarranty() {
    this.service.apporoveWarrantyReq(this.warrantyDetailId)
    .subscribe({
      next: res => {
        this.serviceOwner.getWarrantyList();
        this.serviceOwner.getRequestedWarrantyList();
        this.toastr.success('Updated successfully', 'Warranty Approval')
        this.closeApproveModal();
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
