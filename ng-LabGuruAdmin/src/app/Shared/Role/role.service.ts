
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, of } from "rxjs";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";
import { environment } from "src/environments/environment";

@Injectable()

export class RoleService {
    Token !: string;
    constructor(private http: HttpClient, private authService: AuthenticationService) {
        this.Token = this.authService.GetCurrentUser() as string;
    }
    GetRoleList() {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.get<any>(`${environment.API}/Authentication/GetRoles`, options)
            .pipe(catchError(this.handleError()));
    }

    private handleError() {
        return (error: any): Observable<any> => {
            return of(error.error)
        }
    }
}