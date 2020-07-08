import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  constructor(private auth: AuthenticationService,
              private fb: FormBuilder,
              private router: Router) {}


  ngOnInit() {
    this.form = this.fb.group({
      email: ['', Validators.required, Validators.email],
      password: ['', Validators.required]
    });
  }

  register() {
      this.auth.register(this.form.value).subscribe(result => {
        this.auth.setToken(result.token);
      });

      this.auth.login(this.form.value).subscribe(result => {
        this.auth.setId(result);
      });

      this.router.navigate(['items']).then(() => {
      window.location.reload();
      });
  }
}
