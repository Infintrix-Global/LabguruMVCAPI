import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { IResponce } from "src/app/Shared/responce.model";
import { ILaboratory } from "./Shared/laboratory.model";
import { LaboratoryService } from "./Shared/laboratory.service";

@Component({
    templateUrl: './laboraroty.component.html'
})

export class LabboratoryComponent implements OnInit {
    AppForms!: FormGroup
    mouseover_form: boolean = false;
    LabName!: FormControl
    LabAddress!: FormControl
    ErrorMessage!: string;
    response !: IResponce;
    labList !: ILaboratory[];
    constructor(private labService: LaboratoryService) { }
    ngOnInit() {
        this.LabName = new FormControl('', [Validators.required])
        this.LabAddress = new FormControl('', Validators.required)
        this.AppForms = new FormGroup({
            LabName: this.LabName,
            LabAddress: this.LabAddress
        })
        this.GetLaboratory();
    }
    GetLaboratory() {
        this.labService.Getlaboratory().subscribe(data => {
            this.labList = data;
        })
    }
    SubmitForm() {
        if (this.AppForms.valid) {
            const labModel: ILaboratory = {
                labAddress: this.LabAddress.value,
                labName: this.LabName.value
            }
            this.labService.CreateLaboratory(labModel).subscribe(data => {
                console.log(data)
                this.response = data;
                if (data.isSuccess) {
                    this.GetLaboratory()
                    this.AppForms.reset();
                    this.ErrorMessage = data.message
                }
                else {
                    this.ErrorMessage = data.message
                }
            })
        }

    }
    ValidationLabName() {
        return (this.LabName.valid || this.LabName.untouched);
    }
    ValidationLabAddress() {
        return (this.LabAddress.valid || this.LabAddress.untouched);
    }
}