import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable, OnInit } from "@angular/core";
import { catchError, Observable, of, tap } from "rxjs";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";
import { IResponce } from "src/app/Shared/responce.model";
import { environment } from "src/environments/environment";
import { ILaboratory } from "./laboratory.model";

@Injectable()
export class LaboratoryService {
    constructor(private http: HttpClient, private authService: AuthenticationService) {
        this.Token = this.authService.GetCurrentUser() as string;
    }
    Token !: string;
    Getlaboratory(): Observable<ILaboratory[]> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.get<ILaboratory[]>(`${environment.API}/Laboratory/GetLaboratory`, options)
            .pipe(catchError(this.handleError()));
    }

    CreateLaboratory(laboraroty: ILaboratory): Observable<IResponce> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.post<IResponce>(`${environment.API}/Laboratory/CreateLaboratoryUser`, laboraroty, options)
            .pipe(catchError(this.handleError()));
    }

    private handleError() {
        return (error: any): Observable<any> => {
            return of(error.error)
        }
    }
}