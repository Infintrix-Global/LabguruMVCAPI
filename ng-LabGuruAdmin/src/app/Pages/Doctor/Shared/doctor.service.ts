import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, of } from "rxjs";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";
import { IResponce } from "src/app/Shared/responce.model";
import { environment } from "src/environments/environment";
import { IDoctor } from "./Doctor.model";

@Injectable()
export class DoctorService {
    constructor(private http: HttpClient, private authService: AuthenticationService) {
        this.Token = this.authService.GetCurrentUser() as string;
    }
    Token !: string;
    GetDoctors(): Observable<IDoctor[]> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.get<IDoctor[]>(`${environment.API}/Doctor/GetDoctorList`, options)
            .pipe(catchError(this.handleError()));
    }
    CreateDoctor(Param: any): Observable<IResponce> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.post<IResponce>(`${environment.API}/Doctor/CreateDoctor`, Param, options)
            .pipe(catchError(this.handleError()));
    }


    LabMap(Param: any): Observable<IResponce> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.post<IResponce>(`${environment.API}/Doctor/MapLab`, Param, options)
            .pipe(catchError(this.handleError()));
    }
    GetlabMapped(): Observable<any[]> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.get<any[]>(`${environment.API}/Doctor/GetDoctorLapMapping`, options)
            .pipe(catchError(this.handleError()));
    }
    private handleError() {
        return (error: any): Observable<any> => {
            return of(error.error)
        }
    }
}