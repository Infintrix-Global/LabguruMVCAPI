import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, of } from "rxjs";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";
import { IResponce } from "src/app/Shared/responce.model";
import { environment } from "src/environments/environment";
import { IProcessMaster } from "./ProcessMaster.model";

@Injectable()

export class ProcessMasterService {
    Token !: string;
    constructor(private http: HttpClient, private authService: AuthenticationService) {
        this.Token = this.authService.GetCurrentUser() as string;
    }

    GetProcessMaster(): Observable<IProcessMaster[]> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.get<IProcessMaster[]>(`${environment.API}/ProcessMaster/GetOrderProcess`, options)
            .pipe(catchError(this.handleError()))
    }
    GetProcessMasterByProductID(ProductID: number): Observable<IProcessMaster[]> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        console.log(this.Token)
        return this.http.get<IProcessMaster[]>(`${environment.API}/ProcessMaster/GetOrderProcessByProduct?ProductID=${ProductID}`, options)
            .pipe(catchError(this.handleError()))
    }
    CreateProcessMaster(processMaster: any): Observable<IResponce> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.post<IResponce>(`${environment.API}/ProcessMaster/CreateOrderProcessMaster`, processMaster, options)
            .pipe(catchError(this.handleError()))
    }

    private handleError() {
        return (error: any): Observable<any> => {
            return of(error.error)
        }
    }
}