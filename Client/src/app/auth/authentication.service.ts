import { Injectable } from '@angular/core';
import {environment} from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {executeBrowserBuilder} from '@angular-devkit/build-angular';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  registerPath: string =  environment.identityApiUrl + 'identity/register';
  loginPath: string = environment.identityApiUrl + 'identity/login';
  userIdPath: string = environment.identityApiUrl + 'users/id';
  itemsPath: string = environment.itemsApiUrl + 'items';
  itemDetailsPath: string = environment.itemsApiUrl + 'item-list/id';
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
    return this.http.get(this.userIdPath);
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
}
