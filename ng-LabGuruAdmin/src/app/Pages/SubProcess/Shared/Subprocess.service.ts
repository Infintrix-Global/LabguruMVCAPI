import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";
import { IResponce } from "src/app/Shared/responce.model";
import { environment } from "src/environments/environment";

@Injectable()

export class SubProcessService {
    Token: string;
    constructor(private http: HttpClient, private authService: AuthenticationService) {
        this.Token = authService.GetCurrentUser() as string;
    }

    CreateSubProcess(data: any): Observable<IResponce> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.post<IResponce>(`${environment.API}/SubProcess/AddSubProcess`, data, options)
    }
    GetSubProcess(): Observable<any[]> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.get<any[]>(`${environment.API}/SubProcess/GetSubProcess`, options)
    }
}