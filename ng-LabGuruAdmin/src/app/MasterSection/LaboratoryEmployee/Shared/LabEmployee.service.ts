import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, of } from "rxjs";
import { ILabEmployee } from "./LabEmployee.model";
import { environment } from "src/environments/environment";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";
import { IResponce } from "src/app/Shared/responce.model";
@Injectable()

export class LabEmployeeService {
    Token !: string;
    constructor(private http: HttpClient, private authService: AuthenticationService) {
        this.Token = this.authService.GetCurrentUser() as string;
    }

    CreateLabEmployee(labEmployee: ILabEmployee): Observable<IResponce> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.post<IResponce>(`${environment.API}/Doctor/CreateDoctor`, labEmployee, options)
            .pipe(catchError(this.handleError()))

    }



    GetLabEmployee(LabID: number): Observable<any[]> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.get<any[]>(`${environment.API}/Laboratory/GetLabEmployee?Laboratory=${LabID}`, options)
            .pipe(catchError(this.handleError()))

    }

    private handleError() {
        return (error: any): Observable<any> => {
            return of(error.error)
        }
    }
}