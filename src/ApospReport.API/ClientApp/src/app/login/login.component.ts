import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../shared/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: []
})
export class LoginComponent implements OnInit {

  password = "";
  invalidPassword = false;

  constructor(private authService: AuthService, private cookieService: CookieService) {

  }

  ngOnInit() {
  }

  onLogIn() {
    this.authService.isValidKey(this.password).subscribe(x => {
      if (!x) {
        window.alert("INVALID PASSWORD");
        return;
      }
      this.cookieService.set("X-API-KEY", this.password)
    })
  }

}
