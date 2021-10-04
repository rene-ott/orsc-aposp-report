import { Component } from '@angular/core';
import { AuthService } from '../shared/services/auth.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm = this.fb.group({
    password: ['', Validators.required]
  });

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router) {
  }

  onLogIn() {
    const password = this.loginForm.controls['password'].value;
    this.authService.isValidApiKey(password).subscribe(isValid => {
      if (isValid) {
        this.authService.setApiKey(password);
        this.router.navigate(['/'], { replaceUrl: true })
      } else {
        this.setFormInvalid();
      }
    })
  }

  setFormInvalid() {
    this.loginForm.controls['password'].setErrors({ invalid: true });
  }
}
