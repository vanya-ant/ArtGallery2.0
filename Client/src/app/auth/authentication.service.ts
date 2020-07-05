import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  registerPath: string = environment.identityApiUrl + 'identity/register';
  loginPath: string = environment.identityApiUrl + 'identity/login';
  dealerIdPath: string = environment.identityApiUrl + 'identity/id';
  itemsPath: string = environment.itemsApiUrl + 'items';
  itemDetailsPath: string = environment.itemsApiUrl + 'items/id';
  artistsPath: string = environment.itemsApiUrl + 'artists';
  artistDetailsPath: string = environment.itemsApiUrl + 'artist/id';

  constructor(private http: HttpClient) { }

  register(data): Observable<any> {
    return this.http.post(this.registerPath, data);
  }

  login(data): Observable<any> {
    return this.http.post(this.loginPath, data);
  }

  getUserId(): Observable<any> {
    return this.http.get(this.dealerIdPath);
  }

  setToken(token) {
    localStorage.setItem('token', token);
  }

  setId(userId) {
    localStorage.setItem('userId', userId);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isAuthenticated() {
    return !!this.getToken();
  }
}
