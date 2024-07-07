import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { Auth } from './auth.model';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  url: string = environment.apiBaseUrl;
  formData: Auth = new Auth ()
  loginCred: Auth = new Auth()

  constructor(private http: HttpClient) { }

  register() {
    return this.http.post(this.url+'/registers', this.formData);
  }

  login() {
    return this.http.post(this.url+'/logins', this.formData)
  }

  setUser(userName: string) {
    localStorage.setItem('currentUser', userName);
  }

  getUser(): string | null {
    return localStorage.getItem('currentUser');
  }

  logout(): void {
    localStorage.removeItem('currentUser');
  }
}