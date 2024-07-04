import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { ProductOwner } from './product-owner.model';
import { WarrantyDetail } from './warranty-detail.model';

@Injectable({
  providedIn: 'root'
})
export class ProductOwnerService {

  url: string = environment.apiBaseUrl+'/ProductOwners'
  formData: ProductOwner = new ProductOwner ()
  formSubmitted: boolean = false
  warrantyList: WarrantyDetail[] = []
  productOwner: ProductOwner = new ProductOwner;
  serialNumber!: number;
  validSerial: boolean = false
  invalidSerial: string | null = null
  constructor(private http: HttpClient) { }

  purchaseProduct(selectedProductDetailId: number) {
    this.formData.productDetailId = selectedProductDetailId
    return this.http.post(this.url, this.formData)
  }

  getWarrantyList() {
    return this.http.get(this.url + '/Warranty')
    .subscribe({
      next: res => {
        console.log(res)
        this.warrantyList = res as WarrantyDetail[]
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
        // console.log(res)
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
