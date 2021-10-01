import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AuthService } from "./services/auth.service";

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService, private router: Router) { }

    canActivate() {
        if (true) {
            this.router.navigate(['/dashboard']);
            return true;
        } else {
            this.router.navigate(['/Login']);
        }
        return false;
    }
}
