import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  form: FormGroup;

  constructor(private fb: FormBuilder, private router: Router, private auth: AuthenticationService) {
    if (localStorage.getItem('token')) {
      this.router.navigate(['items-all']);
    }
  }

  ngOnInit() {
    localStorage.removeItem('token');
    this.form = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  login() {
    this.auth.login(this.form.value).subscribe(res => {
      this.auth.setToken(res.token);

      this.auth.getUserId().subscribe(result => {
        this.auth.setId(result);

        this.router.navigate(['']).then(() => {
          window.location.reload();
        });
      });
    });
  }
}
