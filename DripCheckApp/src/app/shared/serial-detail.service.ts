import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { SerialDetail } from './serial-detail.model';

@Injectable({
  providedIn: 'root'
})
export class SerialDetailService {

  url:string = environment.apiBaseUrl+'/SerialDetails'
  list: SerialDetail[] = []
  validSerial: boolean = false
  invalidSerial: string | null = null
  formData: SerialDetail = new SerialDetail()
  constructor(private http: HttpClient) { }

  getSerialDetail() {
    this.http.get(this.url + '/SerialNumber/' + this.formData.serialNumber)
    .subscribe({
      next: res => {
        let valuesArr = Object.values(res)
        this.list = valuesArr
        this.validSerial = true
      },
      error: err => { 
        console.log(err)
        this.invalidSerial = err 
      }
    })
  }
}
