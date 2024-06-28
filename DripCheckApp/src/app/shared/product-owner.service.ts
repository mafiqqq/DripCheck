import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { ProductOwner } from './product-owner.model';

@Injectable({
  providedIn: 'root'
})
export class ProductOwnerService {

  url: string = environment.apiBaseUrl+'/ProductDetails'
  formData: ProductOwner = new ProductOwner ()
  formSubmitted: boolean = false
  constructor(private http: HttpClient) { }

  purchaseProduct(selectedProductDetailId: number) {
    this.formData.productDetailId = selectedProductDetailId
    console.log(this.formData)
    return this.http.post(this.url, this.formData)
  }
}
