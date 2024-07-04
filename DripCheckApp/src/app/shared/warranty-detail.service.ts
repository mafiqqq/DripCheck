import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { WarrantyDetail } from './warranty-detail.model';
import { NgForm } from '@angular/forms';
import { ProductOwner } from './product-owner.model';

@Injectable({
  providedIn: 'root'
})
export class WarrantyDetailService {

  url:string = environment.apiBaseUrl+'/WarrantyDetails'
  // list: WarrantyDetail[] = []
  // warrantyList: [] = []
  formData: WarrantyDetail = new WarrantyDetail ()
  formSubmitted: boolean = false
  constructor(private http: HttpClient) { }

  // refreshList(){
  //   this.http.get(this.url)
  //   .subscribe({
  //     next: res=> {
  //       this.list = res as WarrantyDetail[]
  //     },
  //     error: err=> {console.log(err)}
  //   })
  // }

  postWarrantyDetail() {
    return this.http.post(this.url, this.formData)
  }

  // putWarrantyDetail() {
  //   return this.http.put(this.url + '/' + this.formData.warrantyDetailId, this.formData)
  // }

  deleteWarrantyDetail(id:number) {
    return this.http.delete(this.url + '/' + id)
  }

  resetForm(form:NgForm) {
    form.form.reset()
    this.formData = new WarrantyDetail()
    this.formSubmitted = false
  }

  extendWarrantyDetail(id: number) {
    console.log(this.url + '/' + id.toString())
    return this.http.put(this.url + '/' + id.toString(), id)
  }

}
