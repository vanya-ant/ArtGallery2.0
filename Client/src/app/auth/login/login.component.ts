import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;

  constructor(private fb: FormBuilder, private router: Router, private loginService: LoginService) {
    if (localStorage.getItem('token')) {
      this.router.navigate(['items-all']);
    }
  }

  ngOnInit() {
    localStorage.removeItem('token');
    this.form = this.fb.group({
      email: ['', Validators.required, Validators.email],
      password: ['', Validators.required]
    });
  }

  login() {
    this.loginService.login(this.form.value).subscribe(res => {
      this.loginService.setTToken(res.token);
      this.loginService.setId(res.dealerId);
      window.location.reload();
      this.router.navigate(['cars']);
    });
  }
}
