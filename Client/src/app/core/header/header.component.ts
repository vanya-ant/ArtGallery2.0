import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  token: string;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.getToken();
  }

  getToken() {
    this.token = localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token');
    this.getToken();
    this.router.navigate(['/']);
  }
}
