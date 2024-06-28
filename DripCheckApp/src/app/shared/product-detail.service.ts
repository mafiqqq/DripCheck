import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { ProductDetail } from './product-detail.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ProductDetailService {

  url: string = environment.apiBaseUrl+'/ProductDetails'
  formData: ProductDetail = new ProductDetail ()
  formSubmitted: boolean = false
  productList: ProductDetail[] = []
  constructor(private http: HttpClient) { }

  addProductDetail(imageUrl: string) {
    this.formData.productImageUrl = imageUrl;
    console.log(this.formData)
    return this.http.post(this.url, this.formData)
  }

  getAllProducts() {
    return this.http.get(this.url)
    .subscribe({
      next: res => {
        console.log(res)
        this.productList = res as ProductDetail[]
      },
      error: err => {console.log(err)}
    })
  }

  resetForm(form: NgForm){
    form.form.reset()
    this.formData = new ProductDetail()
    this.formSubmitted = false
  }

}
