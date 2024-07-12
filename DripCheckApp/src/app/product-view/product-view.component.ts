import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ProductOwnerService } from '../shared/product-owner.service';
import { ActivatedRoute } from '@angular/router';
import { ProductOwner } from '../shared/product-owner.model';
import { SafeUrl, SafeValue } from '@angular/platform-browser';
import { WarrantyDetailService } from '../shared/warranty-detail.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Options } from 'ngx-qrcode-styling';
import { AuthService } from '../shared/auth.service';

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



  config: Options = {
    width: 200,
    height: 200,
    image: "assets/images/DripCheckLogo.jpg",
    margin: 5,
    backgroundOptions: {
      color: "#ffffff",
    },
    imageOptions: {
      crossOrigin: "anonymous",
      margin: 0
    }
  };


  constructor(
    public service: ProductOwnerService,
    public serviceWarranty: WarrantyDetailService,
    public authService: AuthService,
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
    this.service.productOwner.loginId = this.authService.getUserId();
  }

  onChangeURL(url: SafeUrl){
    // this.qrCodeSrc = 'http://localhost:4200/api/view-product/1'
    this.qrCodeSrc = url
    console.log(this.qrCodeSrc)
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

  onDownload(qrcode: any): void {
    qrcode.download().subscribe((res: any) => {
      // TO DO something!
      console.log("download:", res);
    });
  }
}
