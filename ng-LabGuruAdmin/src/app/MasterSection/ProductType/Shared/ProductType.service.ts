import { HttpClient, HttpEvent, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthenticationService } from "src/app/Authentication/Shared/authentication.service";
import { IResponce } from "src/app/Shared/responce.model";
import { environment } from "src/environments/environment";
import { IProductType } from "./productType.model";

@Injectable()
export class ProductTypeService {
    constructor(private http: HttpClient, private authService: AuthenticationService) {
        this.Token = this.authService.GetCurrentUser() as string;
    }
    Token !: string;

    GetProductTypes(): Observable<IProductType[]> {
        var url = `${environment.API}/ProductType/GetAllProductType`;
        let UserToken = this.Token;
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': UserToken
            })
        };
        return this.http.get<IProductType[]>(url, options);
    }
    CreateProduct(productType: IProductType): Observable<IResponce> {
        var url = `${environment.API}/ProductType/CreateProductType`;
        let UserToken = this.Token;
        let options = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': UserToken
            })
        };

        return this.http.post<IResponce>(url, productType, options);
    }


    UploadImage(formData: FormData): Observable<any> {
        let UserToken = this.Token;
        formData.forEach(data1 => {
            console.log('Foreach', data1)
        })
        let options = {
            reportProgress: false,
            headers: new HttpHeaders({
                'Authorization': UserToken
            })
        };

        var url = `${environment.API}/Document/ProductType`;
        console.log(url, formData, options);
        return this.http.post(url, formData, options);
    }
}