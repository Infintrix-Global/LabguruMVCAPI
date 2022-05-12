import { Injectable } from "@angular/core";
import {
    ActivatedRouteSnapshot,
    CanActivate,
    Router,
    RouterStateSnapshot,
    UrlTree
} from "@angular/router";
import { Observable } from "rxjs";
import { AuthenticationService } from "../Authentication/Shared/authentication.service";


@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private authService: AuthenticationService, private router: Router) { }

    canActivate() {
        this.authService.CheckAuthGuard().subscribe(data => {
            console.log(data)
            if (!data) {
                this.router.navigate(['/login'])
            }
        })
        return true;
    }
}
