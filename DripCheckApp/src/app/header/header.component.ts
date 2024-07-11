import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { Auth } from '../shared/auth.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: [
  ]
})
export class HeaderComponent implements OnInit {
  title = 'Drip Check'

  user: string | null = null;
  userId: string | null = null;

  // constructor(private activatedRoute: ActivatedRoute) {}
  // @Input()
  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService) {}

  ngOnInit(): void {
    this.user = this.authService.getUser();
    this.userId = this.authService.getUserId();
    console.log(this.user)
    console.log(this.userId)
  }

  logout(): void {
    this.authService.logout()
    this.toastr.success('Logout successfully', 'User Logout')
    this.router.navigate(['/'])
  }

}
