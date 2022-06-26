import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { LaboratoryService } from "src/app/MasterSection/Laboratory/Shared/laboratory.service";
import { IResponce } from "src/app/Shared/responce.model";
import { DoctorService } from "../Shared/doctor.service";

@Component({
    templateUrl: './LabMap.component.html'
})

export class LabMappingComponent implements OnInit {
    AppForms!: FormGroup
    mouseover_form: boolean = false;
    response !: IResponce;
    DoctorID !: FormControl;
    LabID !: FormControl;
    DoctorList !: any[];
    LabList !: any[];
    LabMappedList !: any[];
    constructor(private doctorService: DoctorService, private LabService: LaboratoryService) {

    }
    ngOnInit() {
        this.GetDoctor();
        this.GetLab();
        this.AppFormInit();
        this.GetDOctorLabMap();

    }
    AppFormInit() {
        this.DoctorID = new FormControl('', Validators.required)
        this.LabID = new FormControl('', Validators.required)
        this.AppForms = new FormGroup({
            LabID: this.LabID,
            DoctorID: this.DoctorID,
        })
    }
    SubmitForm() {
        const param: any = {
            DoctorID: this.DoctorID.value,
            LabID: this.LabID.value
        }
        this.doctorService.LabMap(param).subscribe(data => {
            this.response = data;
            if (this.response.isSuccess) {
                this.AppForms.reset();
            }
        })
    }
    GetDoctor() {
        this.doctorService.GetDoctors().subscribe((data) => {
            console.log(data)
            this.DoctorList = data;
        })
    }

    GetLab() {
        this.LabService.Getlaboratory().subscribe((data) => {
            console.log(data)
            this.LabList = data;
        })
    }

    GetDOctorLabMap() {
        this.doctorService.GetlabMapped().subscribe((data) => {
            this.LabMappedList = data;
        })
    }
}