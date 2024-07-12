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
  productInfo: ProductDetail = new ProductDetail ()
  serialNumArray: string[] = [];
  constructor(private http: HttpClient) { }

  addProductDetail(imageUrls: {[key:string]: string} ) {
    console.log(this.formData.productSerialNumbersText)
    if (this.formData.productSerialNumbersText.trim()) {
      this.serialNumArray = this.formData.productSerialNumbersText.split('\n').filter(line => line.trim() !== '');
    } else {
      this.serialNumArray = [];
    }
    console.log(this.serialNumArray)
    this.formData.serialNumbers = this.serialNumArray;
    console.log(this.formData)
    this.formData.productImageUrl1 = imageUrls["imageUrl1"];
    this.formData.productImageUrl2 = imageUrls["imageUrl2"];
    this.formData.productImageUrl3 = imageUrls["imageUrl3"];
    return this.http.post(this.url, this.formData)
  }

  updateProductDetail(id: number) {
    console.log(this.formData.productSerialNumbersText)
    if (this.formData.productSerialNumbersText.trim()) {
      this.serialNumArray = this.formData.productSerialNumbersText.split('\n').filter(line => line.trim() !== '');
    } else {
      this.serialNumArray = [];
    }
    console.log(this.serialNumArray)
    this.formData.serialNumbers = this.serialNumArray;
    console.log(this.formData)
    return this.http.put(this.url + '/Restock/' + id, this.serialNumArray)
  }

  getAllProducts() {
    return this.http.get(this.url)
    .subscribe({
      next: res => {
        this.productList = res as ProductDetail[]
      },
      error: err => {console.log(err)}
    })
  }

  getFullProductInfo(id: string) {
    return this.http.get(this.url + '/' + id)
    .subscribe({
      next: res => {
        console.log(res)
        this.productInfo = res as ProductDetail
      },
      error: err => {
        console.log(err)
      }
    })
  }

  resetForm(form: NgForm){
    form.form.reset()
    this.formData = new ProductDetail()
    this.formSubmitted = false
  }

}
