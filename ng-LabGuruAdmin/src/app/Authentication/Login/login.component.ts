import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { catchError, Observable, of, tap } from "rxjs";
import { IResponce } from "src/app/Shared/responce.model";
import { environment } from "src/environments/environment";
import { AuthenticationService } from "../Shared/authentication.service";

@Component({
    templateUrl: './login.component.html'
})

export class LoginComponent implements OnInit {
    LoginForm!: FormGroup
    mouseover_form: boolean = false;
    Username!: FormControl
    Password!: FormControl
    ErrorMessage!: string;

    constructor(private AuthService: AuthenticationService, private router: Router) { }
    ngOnInit() {
        localStorage.clear();
        this.Username = new FormControl('', [Validators.required])
        this.Password = new FormControl('', Validators.required)
        this.LoginForm = new FormGroup({
            Username: this.Username,
            Password: this.Password
        })
    }

    Login() {
        if (this.LoginForm.valid) {
            this.AuthService.LoginWithPassword(this.Username.value, this.Password.value).subscribe(data => {
                console.log(data)
                if (!data.isSuccess) {
                    this.ErrorMessage = data.message;
                }
                else {
                    this.router.navigate(['/dashboard']);
                }
            });
        }
    }
    ValidateUsername() {
        return (this.Username.valid || this.Username.untouched);
    }
    ValidatePassword() {
        return (this.Password.valid || this.Password.untouched);
    }

}