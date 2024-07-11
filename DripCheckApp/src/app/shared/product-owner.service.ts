import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { ProductDetail } from './product-detail.model';
import { ProductOwner } from './product-owner.model';
import { WarrantyDetail } from './warranty-detail.model';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class ProductOwnerService {

  url: string = environment.apiBaseUrl+'/ProductOwners'
  formData: ProductOwner = new ProductOwner ()
  formSubmitted: boolean = false
  warrantyList: WarrantyDetail[] = []
  requestedWarrantyList: WarrantyDetail[] = []
  productOwner: ProductOwner = new ProductOwner;
  productInfo: ProductDetail = new ProductDetail;
  serialNumber!: number;
  validSerial: boolean = false
  invalidSerial: string | null = null
  constructor(
    private http: HttpClient,
    public authService: AuthService
  ) { }

  purchaseProduct(selectedProductDetailId: number) {
    this.formData.productDetailId = selectedProductDetailId
    this.formData.loginId = this.authService.getUserId()
    console.log(this.formData)
    return this.http.post(this.url, this.formData)
  }

  getWarrantyList() {
    return this.http.get(this.url + '/Warranty')
    .subscribe({
      next: res => {
        this.warrantyList = res as WarrantyDetail[]
      },
      error: err => {
        console.log(err)
      }
    })
  }

  getRequestedWarrantyList() {
    return this.http.get(this.url + '/RequestedWarranty')
    .subscribe({
      next: res => {
        this.requestedWarrantyList = res as WarrantyDetail[]
      },
      error: err => {
        console.log(err)
      }
    }) 
  }

  checkSerialNumber() {
    return this.http.get(this.url + '/SerialNumber/' + this.serialNumber)
  }

  getFullProduct(id: string) {
    return this.http.get(this.url + '/' + id)
    .subscribe({
      next: res => {
        this.productOwner = res as ProductOwner
      },
      error: err => {
        console.log(err)
      }
    })
  }

  viewProductDetail(id: number) {
    return this.http.get(this.url + '/' + id)
  }
}
