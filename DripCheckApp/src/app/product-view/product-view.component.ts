import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ProductOwnerService } from '../shared/product-owner.service';
import { ActivatedRoute } from '@angular/router';
import { ProductOwner } from '../shared/product-owner.model';
import { SafeUrl, SafeValue } from '@angular/platform-browser';
import { FixMeLater } from 'angularx-qrcode';
import { WarrantyDetailService } from '../shared/warranty-detail.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

declare var bootstrap: any;

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styles: [
  ]
})
export class ProductViewComponent implements OnInit {

  id!: string;
  qrCodeDownloadLink: SafeValue ='';
  qrCodeSrc!: SafeUrl;
  angxUrl: string = "";
  angxUrlDl!: SafeUrl;
  @ViewChild('warrantyModal') warrantyModal!: ElementRef;
  selectedDuration!: number;
  warrantyDetailId!: number;
  reqReason: string = "";
  constructor(
    public service: ProductOwnerService,
    public serviceWarranty: WarrantyDetailService,
    private route: ActivatedRoute,
    private toastr:ToastrService) {

  }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id') || '';
    // this.angxUrl = "http://localhost:4200/view-product/" + this.id;
    // this.angxUrlDl = this.angxUrl
    this.refreshList();
  }

  // extendWarranty() {
  //   console.log(this.reqReason)
  //   // this.serviceWarranty.extendWarrantyDetailUser(this.warrantyDetailId, this.selectedDuration)
  //   // .subscribe({
  //   //   next: res => {
  //   //     this.refreshList()
  //   //     this.toastr.success('Updated successfully', 'Warranty Update')
  //   //   },
  //   //   error: err => {
  //   //     console.log(err)
  //   //   }
  //   // })
  // }

  extendWarranty(form:NgForm) {
    this.serviceWarranty.extendWarrantyDetailUser(this.warrantyDetailId, this.selectedDuration)
    .subscribe({
      next: res => {
        this.refreshList()
        this.toastr.success('Updated successfully', 'Warranty Update')
        this.closeModal();
      },
      error: err => {
        console.log(err)
      }
    })
  }

  openExtendedWarrantyModel(id: number){
    this.warrantyDetailId = id;
    const modalW = new bootstrap.Modal(this.warrantyModal.nativeElement);
    modalW.show(); 
  }

  closeModal() {
    // const modalW = new bootstrap.Modal(this.warrantyModal.nativeElement);
    // modalW.hide();
    const modalElementW = document.getElementById('warrantyModal');
    const modalInstanceW = bootstrap.Modal.getInstance(modalElementW);
    modalInstanceW.hide();
  }

  selectDuration(duration: number) {
    this.selectedDuration = duration;
  }

  refreshList() {
    this.service.getFullProduct(this.id);
  }

  onChangeURL(url: SafeUrl){
    this.qrCodeSrc = url
    console.log(this.qrCodeSrc)
  }

  saveAsImage(parent: FixMeLater) {
    let parentElement = null

    console.log(parent.qrcElement)
    parentElement = parent.qrcElement.nativeElement
    .querySelector("canvas")
    .toDataURL("image/png")

    if (parentElement) {
      // converts base 64 encoded image to blobData
      let blobData = this.convertBase64ToBlob(parentElement)
      console.log(blobData)
      // saves as image
      const blob = new Blob([blobData], { type: "image/png" })
      const url = window.URL.createObjectURL(blob)
      console.log(url)
      const link = document.createElement("a")
      console.log(this.angxUrl)
      link.href = this.angxUrl
      // name of the file
      link.download = "angularx-qrcode"
      link.click()
    }

  }

  convertBase64ToBlob(Base64Image: string) {
    // split into two parts
    const parts = Base64Image.split(";base64,")
    // hold the content type
    const imageType = parts[0].split(":")[1]
    // decode base64 string
    const decodedData = window.atob(parts[1])
    // create unit8array of size same as row data length
    const uInt8Array = new Uint8Array(decodedData.length)
    // insert all character code into uint8array
    for (let i = 0; i < decodedData.length; ++i) {
      uInt8Array[i] = decodedData.charCodeAt(i)
    }
    // return blob image after conversion
    return new Blob([uInt8Array], { type: imageType })
  }

}
