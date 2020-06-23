import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from './register.service';
import { Router } from '@angular/router';
import { RegisterModel } from './register-model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  constructor(private registerService: RegisterService,
              private fb: FormBuilder,
              private router: Router) {}


  ngOnInit() {
    this.form = this.fb.group({
      email: ['', Validators.required, Validators.email],
      password: ['', Validators.required]
    });
  }

  login() {
    this.registerService.register(this.form.value).subscribe(res => {
      this.router.navigate(['auth']);
    });
  }
}
