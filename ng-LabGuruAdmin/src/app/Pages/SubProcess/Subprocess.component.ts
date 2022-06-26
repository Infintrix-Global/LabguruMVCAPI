import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { LaboratoryService } from "src/app/Shared/Laboratory/laboratory.service";
import { ProcessMasterService } from "src/app/MasterSection/ProcessMaster/Shared/ProcessMaster.service";
import { IResponce } from "src/app/Shared/responce.model";
import { SubProcessService } from "./Shared/Subprocess.service";

@Component({
    templateUrl: './Subprocess.component.html'
})
export class SubProcessCompaonent implements OnInit {
    response !: IResponce;
    AppForms !: FormGroup;
    LabID!: FormControl;
    ProcessID !: FormControl;
    SubProcessName  !: FormControl;
    mouseover_form: boolean = false;
    isFormSubmiting: boolean = false;
    labList !: any[];
    processList !: any[];
    constructor(private labSer: LaboratoryService, private processMaster: ProcessMasterService, private SubProcessMaster: SubProcessService) { }
    ngOnInit() {
        this.GetLabs();
        this.AppFormInit();
        this.GetProcessMaster();
    }
    AppFormInit() {
        this.LabID = new FormControl('', Validators.required)
        this.ProcessID = new FormControl("", Validators.required)
        this.SubProcessName = new FormControl("", Validators.required)

        this.AppForms = new FormGroup({
            LabID: this.LabID,
            ProcessID: this.ProcessID,
            SubProcessName: this.SubProcessName

        });
    }
    SubmitForm() {
        this.isFormSubmiting = true;
        const Param = {
            ProcessID: this.ProcessID.value,
            SubProcessName: this.SubProcessName.value,
            IsActive: true
        }
        this.SubProcessMaster.CreateSubProcess(Param).subscribe(data => {
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
}