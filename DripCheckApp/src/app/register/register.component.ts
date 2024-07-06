import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { AuthService } from '../shared/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: [
  ]
})
export class RegisterComponent {

  constructor(
    public service: AuthService,
    private router: Router,
    private toastr: ToastrService
  ){}

  onSubmit(form:NgForm) {
    this.service.register()
    .subscribe({
      next: res => {
        this.toastr.success('User Registered successfully', 'User Registration')
        console.log(res)
      },
      error: err => {
        console.log(err)
      }
    })
  }
}
