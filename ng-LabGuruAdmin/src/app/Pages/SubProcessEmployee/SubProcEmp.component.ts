import { Component } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { LaboratoryService } from "src/app/MasterSection/Laboratory/Shared/laboratory.service";
import { LabEmployeeService } from "src/app/MasterSection/LaboratoryEmployee/Shared/LabEmployee.service";
import { ProcessMasterService } from "src/app/MasterSection/ProcessMaster/Shared/ProcessMaster.service";
import { IResponce } from "src/app/Shared/responce.model";
import { SubProcessService } from "../SubProcess/Shared/Subprocess.service";
import { SubProcessEmpService } from "./Shared/subprocessemp.service";

@Component({
    templateUrl: './SubProcEmp.component.html'
})
export class SubProcessEmployeeComponent {
    response !: IResponce;
    AppForms !: FormGroup;
    LabID!: FormControl;
    ProcessID !: FormControl;
    SubProcessName  !: FormControl;
    mouseover_form: boolean = false;
    isFormSubmiting: boolean = false;
    labList !: any[];
    LabEmpLst !: any[];
    processList !: any[];
    subprocessList !: any[];
    constructor(private labSer: LaboratoryService, private processMaster: ProcessMasterService, private SubProcessMaster: SubProcessService,
        private LabEmpSer: LabEmployeeService, private SubProceEmpServ: SubProcessEmpService) { }
    ngOnInit() {
        this.GetLabs();
        this.AppFormInit();
        this.GetSubProcessMaster();
    }
    AppFormInit() {
        this.LabID = new FormControl('', Validators.required)
        this.ProcessID = new FormControl("", Validators.required)

        this.AppForms = new FormGroup({
            LabID: this.LabID,
            ProcessID: this.ProcessID

        });
    }
    SubmitForm() {
        this.isFormSubmiting = true;
        const Param = {
            SubProcessID: this.ProcessID.value,
            LabEmployeeID: this.LabID.value,
            IsActive: true
        }
        this.SubProceEmpServ.CreateSubProcesEmp(Param).subscribe(data => {
            this.response = data;
            if (data) {
                this.isFormSubmiting = false;
                this.AppForms.reset();
            }
        })
    }
    GetLabs() {
        this.labSer.Getlaboratory().subscribe(data => {
            this.labList = data;
        })
    }
    GetProcessMaster() {
        this.processMaster.GetProcessMaster().subscribe(data => {
            this.processList = data;
        })
    }

    GetSubProcessMaster() {
        this.SubProcessMaster.GetSubProcess().subscribe(data => {
            this.subprocessList = data;
        })
    }
    GetLabEmployee(LabID: any) {
        this.LabEmpSer.GetLabEmployee(LabID).subscribe(data => {
            this.LabEmpLst = data;
        })
    }
}