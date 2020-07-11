import { Injectable } from '@angular/core';
import {CanActivate, Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthGuardGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(): boolean {
    if (!this.isAdmin(this.getToken())) {
      this.router.navigate(['/login']);
      return false;
    }
    return true;
  }

  getToken() {
    return localStorage.getItem('token');
  }

  isAdmin(token) {
    const jwtData = token.split('.')[1];
    const decodedJwtJsonData = window.atob(jwtData);
    const decodedJwtData = JSON.parse(decodedJwtJsonData);

    const role = decodedJwtData.Role;
    if (role === 'Admin') {
      return true;
    }

    return false;
  }
}
