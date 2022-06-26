import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { IResponce } from "src/app/Shared/responce.model";
import { RoleService } from "src/app/Shared/Role/role.service";
import { ILaboratory } from "../../Shared/Laboratory/laboratory.model";
import { LaboratoryService } from "../../Shared/Laboratory/laboratory.service";
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
    RoleID !: FormControl;
    mouseover_form: boolean = false;
    response !: IResponce;
    RoleList !: any[];
    employeeList !: any[];
    AllemployeeList !: any[];
    constructor(private LabService: LaboratoryService, private LabEmpService: LabEmployeeService, private roleService: RoleService) { }
    ngOnInit(): void {
        this.GetLabList();
        this.AppFormInit();
        this.GetEmployeeList();
        this.GetRoleList();
    }

    AppFormInit() {

        this.LabID = new FormControl('', Validators.required)
        this.employeeName = new FormControl('', Validators.required)
        this.Username = new FormControl('', Validators.required)
        this.RoleID = new FormControl('', Validators.required)
        this.AppForms = new FormGroup({
            RoleID: this.RoleID,
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
    ChangeLab(data: number) {
        if (data) {
            this.employeeList = this.AllemployeeList.filter(w => w.labID == data)
        }
        else {
            this.employeeList = this.AllemployeeList;
        }
    }
    SubmitForm() {
        const labEmp: ILabEmployee = {
            EmployeeName: this.employeeName.value,
            LabID: this.LabID.value,
            RoleID: this.RoleID.value,
            UserName: this.Username.value
        }
        this.LabEmpService.CreateLabEmployee(labEmp).subscribe(data => {
            this.response = data;
            if (this.response.isSuccess) {
                this.AppForms.reset();
                this.GetEmployeeList();
            }
        })
    }
    GetRoleList() {
        this.roleService.GetRoleList().subscribe(data => {
            console.log(data);
            this.RoleList = data;
        })
    }

    GetEmployeeList() {
        this.LabEmpService.GetLabEmployee(0).subscribe(data => {
            this.employeeList = data;
            this.AllemployeeList = data;
        })
    }
}