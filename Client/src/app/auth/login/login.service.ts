import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loginPath: string = environment.apiUrl + 'identity/login';

  constructor(private http: HttpClient) { }

  login(payload): Observable<any> {
    return this.http.post(this.loginPath, payload);
  }

  setTToken(token) {
    localStorage.setItem('token', token);
  }

  setId(userId) {
    localStorage.setItem('userId', userId);
  }
}
