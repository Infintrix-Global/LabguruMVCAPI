import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html'
})

export class HeaderComponent {
    constructor(public AuthService: AuthenticationService, private router: Router) { }
    Logout() {
        localStorage.clear();
        this.router.navigate(['/login'])
    }
}