import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, of, tap } from "rxjs";
import { IResponce } from "src/app/Shared/responce.model";
import { environment } from "src/environments/environment";

@Injectable()
export class AuthenticationService {
    constructor(private http: HttpClient) { }
    CurrentUser !: any;
    LoginWithPassword(Username: string, Password: string): Observable<IResponce> {
        let body = {
            "Username": Username,
            "Password": Password
        }
        return this.http.post<IResponce>(`${environment.API}/Authentication/Login`, body)
            .pipe(tap((data) => {
                let d = data;
                if (d.isSuccess) {
                    localStorage.setItem('X-Auth-Token', 'Bearer ' + d.data.token);
                    localStorage.setItem('X-Auth-role', d.data.role);
                }
            }))
            .pipe(catchError(this.handleError<IResponce>('Login With PaSSWORD')));
    }

    private handleError<T>(opration = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            // console.error(opration)
            return of(error.error as T)
        }
    }

    CheckAuthGuard() {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': '' + this.GetCurrentUser()
            })
        };
        let ReqURL = `${environment.API}/Authentication/authguard`;
        return this.http.get<any>(ReqURL, options)
            .pipe(tap(data => {
                this.CurrentUser = data
            }))
            .pipe(catchError(err => {
                return of(false)
            }));
    }
    GetCurrentUser() {
        if (!localStorage.getItem('X-Auth-Token')) {
            return '';
        } else {
            return localStorage.getItem('X-Auth-Token')?.toString();
        }

    }
}