import { Component } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Auth } from '../shared/auth.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent {

  loginCred: Auth = new Auth;
  constructor(
    public service: AuthService, 
    private toastr: ToastrService,
    private router: Router) {}

  onSubmit(form: NgForm){
    this.service.login()
    .subscribe({
      next: res => {
        this.loginCred = res as Auth
        console.log(this.loginCred)
        this.service.setUser(this.loginCred.username)
        this.service.setUserId(this.loginCred.loginId)
        if (this.loginCred.username === 'admin') {
          this.router.navigate(['/warranty'])
        } else {
          this.router.navigate(['/all-products'])
        }
        this.toastr.success('Login successfully', 'User Login')
      },
      error: err => {
        alert('Invalid username or password')
      }
    })
  }
}
