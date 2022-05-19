import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { IResponce } from "src/app/Shared/responce.model";
// import { IDoctor } from "../Shared/Doctor.model";
import { DoctorService } from "../Shared/doctor.service";

@Component({
    templateUrl: './doctor.component.html'
})

export class DoctorComponent implements OnInit {
    AppForms!: FormGroup
    mouseover_form: boolean = false;

    FirstName!: FormControl
    MiddleName!: FormControl
    LastName!: FormControl
    Gender!: FormControl
    Email!: FormControl
    BloodGroup!: FormControl
    Mobile1!: FormControl
    Mobile2!: FormControl
    Residential_Address!: FormControl
    Line1!: FormControl
    Line2!: FormControl

    AreaPin!: FormControl
    UserName!: FormControl
    Password!: FormControl

    RegistrationNo!: FormControl
    PanCardNo!: FormControl
    PanCardImageUrl!: FormControl
    AdharCardNo!: FormControl
    AdharCardImageUrl!: FormControl
    ProfileImageUrl!: FormControl
    RegistrationImageUrl!: FormControl
    IdentityPolicyNo!: FormControl
    IdentityPolicyImageUrl!: FormControl

    ErrorMessage!: string;
    response !: IResponce;
    docList !: any[];
    constructor(private DocService: DoctorService) { }
    ngOnInit() {

        this.AppFormInit();
        this.GetLaboratory();
    }

    AppFormInit() {

        this.FirstName = new FormControl('', Validators.required)
        this.MiddleName = new FormControl()
        this.LastName = new FormControl('', Validators.required)
        this.Gender = new FormControl('', Validators.required)
        this.Email = new FormControl()
        this.BloodGroup = new FormControl()
        this.Mobile1 = new FormControl('', Validators.required)
        this.Mobile2 = new FormControl()
        this.Residential_Address = new FormControl('', Validators.required)
        this.Line1 = new FormControl()
        this.Line2 = new FormControl()

        this.AreaPin = new FormControl()
        this.UserName = new FormControl('', Validators.required)
        this.Password = new FormControl('', Validators.required)

        this.RegistrationNo = new FormControl()
        this.PanCardNo = new FormControl()
        this.PanCardImageUrl = new FormControl()
        this.AdharCardNo = new FormControl()
        this.AdharCardImageUrl = new FormControl()
        this.ProfileImageUrl = new FormControl()
        this.RegistrationImageUrl = new FormControl()
        this.IdentityPolicyNo = new FormControl()
        this.IdentityPolicyImageUrl = new FormControl()


        this.AppForms = new FormGroup({

            FirstName: this.FirstName,
            MiddleName: this.MiddleName,
            LastName: this.LastName,
            Gender: this.Gender,
            Email: this.Email,
            BloodGroup: this.BloodGroup,
            Mobile1: this.Mobile1,
            Mobile2: this.Mobile2,
            Residential_Address: this.Residential_Address,
            Line1: this.Line1,
            Line2: this.Line2,

            AreaPin: this.AreaPin,
            UserName: this.UserName,
            Password: this.Password,
            RegistrationNo: this.RegistrationNo,
            PanCardNo: this.PanCardNo,
            PanCardImageUrl: this.PanCardImageUrl,
            AdharCardNo: this.AdharCardNo,
            AdharCardImageUrl: this.AdharCardImageUrl,
            ProfileImageUrl: this.ProfileImageUrl,
            RegistrationImageUrl: this.RegistrationImageUrl,
            IdentityPolicyNo: this.IdentityPolicyNo,
            IdentityPolicyImageUrl: this.IdentityPolicyImageUrl,

        })
    }
    GetLaboratory() {
        this.DocService.GetDoctors().subscribe(data => {
            this.docList = data;
        })
    }
    SubmitForm() {
        const regDate = new Date();
        if (this.AppForms.valid) {
            const docModel: any = {
                DoctorTypeID: 0,
                ClinicID: 0,
                RegDate: regDate,
                FirstName: this.FirstName.value,
                MiddleName: this.MiddleName.value,
                LastName: this.LastName.value,
                Gender: this.Gender.value,
                Email: this.Email.value,
                BloodGroup: this.BloodGroup.value,
                Mobile1: this.Mobile1.value,
                Mobile2: this.Mobile2.value,
                Residential_Address: this.Residential_Address.value,
                Line1: this.Line1.value,
                Line2: this.Line2.value,
                CountryID: 0,
                StateID: 0,
                CityID: 0,
                LocationID: 0,
                ModifiedDate: regDate,
                ModifiedBy: 0,
                IsActive: true,
                OTP: '',
                IsDeleted: false,
                AreaPin: this.AreaPin.value,
                UserName: this.UserName.value,
                Password: this.Password.value,
                RegistrationNo: this.RegistrationNo.value,
                PanCardNo: this.PanCardNo.value,
                PanCardImageUrl: this.PanCardImageUrl.value,
                AdharCardNo: this.AdharCardNo.value,
                AdharCardImageUrl: this.AdharCardImageUrl.value,
                ProfileImageUrl: this.ProfileImageUrl.value,
                RegistrationImageUrl: this.RegistrationImageUrl.value,
                IdentityPolicyNo: this.IdentityPolicyNo.value,
                IdentityPolicyImageUrl: this.IdentityPolicyImageUrl.value,
                RoleID: 1,
                CreatedDate: regDate,
                InTime: '10:00:00',
                OutTime: '16:00:00',
                IsExistUser: false,
                isTermAccept: true,

            }
            this.DocService.CreateDoctor(docModel).subscribe(data => {
                console.log(data)
                this.response = data;
                if (data.isSuccess) {
                    this.AppForms.reset();
                    this.ErrorMessage = data.message
                }
                else {
                    this.ErrorMessage = data.message
                }
            })
        }

    }
}