import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";
import { IResponce } from "src/app/Shared/responce.model";
import { environment } from "src/environments/environment";

@Injectable()
export class SubProcessEmpService {
    Token: string;
    constructor(private authservi: AuthenticationService, private http: HttpClient) {
        this.Token = authservi.GetCurrentUser() as string;
    }
    CreateSubProcesEmp(data: any): Observable<IResponce> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.post<IResponce>(`${environment.API}/SubProcess/AddSubProcessEmployee`, data, options);
    }
}