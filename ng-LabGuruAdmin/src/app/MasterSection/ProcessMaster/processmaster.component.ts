import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { IResponce } from "src/app/Shared/responce.model";
import { IProcessMaster } from "./Shared/ProcessMaster.model";
import { ProcessMasterService } from "./Shared/ProcessMaster.service";

@Component({
    templateUrl: './processmaster.component.html'
})

export class ProcessMasterComponent implements OnInit {
    ProcessList !: IProcessMaster[];
    AppForms!: FormGroup
    ProcessMasterName !: FormControl;
    mouseover_form: boolean = false;
    response !: IResponce;
    constructor(private processMasterService: ProcessMasterService) { }
    ngOnInit(): void {
        this.AppFormInit();
    }
    AppFormInit() {
        this.GetProcessMaster();
        this.ProcessMasterName = new FormControl('', Validators.required)
        this.AppForms = new FormGroup({
            ProcessMasterName: this.ProcessMasterName,
        })
    }

    GetProcessMaster() {
        this.processMasterService.GetProcessMaster().subscribe(data => {
            this.ProcessList = data;
        })
    }
    SubmitForm() {
        const labEmp: IProcessMaster = {
            processName: this.ProcessMasterName.value,
        }
        this.processMasterService.CreateProcessMaster(labEmp).subscribe(data => {
            this.response = data;
            if (this.response.isSuccess) {
                this.AppForms.reset();
                this.GetProcessMaster();
            }
        })
    }
}