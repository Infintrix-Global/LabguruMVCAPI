import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";
import { IResponce } from "src/app/Shared/responce.model";
import { environment } from "src/environments/environment";

@Injectable()
export class ProcessMapperService {
    Token: string;
    constructor(private http: HttpClient, private authServi: AuthenticationService) {
        this.Token = authServi.GetCurrentUser() as string;
    }
    GetProcessMapper(): Observable<any[]> {
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };
        return this.http.get<any[]>(`${environment.API}/ProcessMaster/GetProcessMapper`, options);
    }
    CreateProcessMapper(ProcessMapper: any): Observable<IResponce> {
        var url = `${environment.API}/ProcessMaster/CreateProcessMapper`;
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': this.Token
            })
        };

        return this.http.post<IResponce>(url, ProcessMapper, options);
    }
}