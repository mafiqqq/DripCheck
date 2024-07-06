import { Component } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent {

  constructor(public service: AuthService, private toastr: ToastrService) {}

  onSubmit(form: NgForm){
    this.service.login()
    .subscribe({
      next: res => {
        this.toastr.success('Login successfully', 'User Login')
        console.log(res)
      },
      error: err => {
        console.log(err)
      }
    })
  }
}
