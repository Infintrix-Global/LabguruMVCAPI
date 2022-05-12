import { Component } from "@angular/core";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html'
})

export class sidebarComponent {
    constructor(public AuthService: AuthenticationService) { }
}