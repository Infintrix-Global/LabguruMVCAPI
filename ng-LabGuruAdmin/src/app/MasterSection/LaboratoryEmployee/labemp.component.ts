import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { IResponce } from "src/app/Shared/responce.model";
import { ILaboratory } from "../Laboratory/Shared/laboratory.model";
import { LaboratoryService } from "../Laboratory/Shared/laboratory.service";
import { ILabEmployee } from "./Shared/LabEmployee.model";
import { LabEmployeeService } from "./Shared/LabEmployee.service";

@Component({
    templateUrl: './labemp.component.html'
})
export class LabEmployeeComponent implements OnInit {
    LabList !: ILaboratory[];
    AppForms!: FormGroup
    LabID !: FormControl;
    employeeName !: FormControl;
    Username !: FormControl;
    mouseover_form: boolean = false;
    response !: IResponce;
    constructor(private LabService: LaboratoryService, private LabEmpService: LabEmployeeService) { }
    ngOnInit(): void {
        this.GetLabList();
        this.AppFormInit();
    }

    AppFormInit() {

        this.LabID = new FormControl('', Validators.required)
        this.employeeName = new FormControl('', Validators.required)
        this.Username = new FormControl('', Validators.required)
        this.AppForms = new FormGroup({

            LabID: this.LabID,
            employeeName: this.employeeName,
            Username: this.Username,
        })
    }
    GetLabList() {
        this.LabService.Getlaboratory().subscribe(data => {
            this.LabList = data;
        })
    }

    SubmitForm() {
        const labEmp: ILabEmployee = {
            EmployeeName: this.employeeName.value,
            LabID: this.LabID.value,
            RoleID: 2,
            UserName: this.Username.value
        }
        this.LabEmpService.CreateLabEmployee(labEmp).subscribe(data => {
            this.response = data;
            if (this.response.isSuccess) {
                this.AppForms.reset();
            }
        })
    }
}