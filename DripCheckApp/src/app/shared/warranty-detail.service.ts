import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
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
  reqReason: string = "";
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

  extendWarrantyDetailAdmin(id: number, year: number) {
    const params = new HttpParams().set('duration', year.toString())
    return this.http.put(this.url + '/Admin/' + id.toString(), {}, { params })
  }

  extendWarrantyDetailUser(id: number, year: number) {
    console.log('her' + this.reqReason)
    console.log(id)
    console.log(year)
    const params = new HttpParams()
    .set('duration', year.toString())
    .set('reason', this.reqReason)
    console.log(params)
    return this.http.put(this.url + '/User/' + id.toString(),{}, { params } )
  }

  apporoveWarrantyReq(id: number) {
    return this.http.put(this.url + '/UserApprove/' + id, id)
  }

}
