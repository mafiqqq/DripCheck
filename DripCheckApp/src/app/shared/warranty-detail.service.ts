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
  formData: WarrantyDetail = new WarrantyDetail ()
  formSubmitted: boolean = false
  constructor(private http: HttpClient) { }

  postWarrantyDetail() {
    return this.http.post(this.url, this.formData)
  }

  deleteWarrantyDetail(id:number) {
    return this.http.delete(this.url + '/' + id)
  }

  resetForm(form:NgForm) {
    form.form.reset()
    this.formData = new WarrantyDetail()
    this.formSubmitted = false
  }

  extendWarrantyDetail(id: number, year: number) {
    console.log(this.url + '/' + id.toString())
    return this.http.put(this.url + '/' + id.toString(), id)
  }

}
