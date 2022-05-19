import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { IResponce } from "src/app/Shared/responce.model";
import { ProductTypeService } from "../ProductType/Shared/ProductType.service";
import { IProcessMaster } from "./Shared/ProcessMaster.model";
import { ProcessMasterService } from "./Shared/ProcessMaster.service";

@Component({
    templateUrl: './processmaster.component.html'
})

export class ProcessMasterComponent implements OnInit {
    ProcessList !: any[];
    AppForms!: FormGroup
    ProcessMasterName !: FormControl;
    ProductID !: FormControl;
    prodList !: any;
    mouseover_form: boolean = false;
    response !: IResponce;
    isFormSubmiting: boolean = false;
    constructor(private processMasterService: ProcessMasterService, private product: ProductTypeService) { }
    ngOnInit(): void {
        this.GetProductType();
        this.AppFormInit();
    }
    AppFormInit() {
        this.GetProcessMaster();
        this.ProcessMasterName = new FormControl('', Validators.required)
        this.ProductID = new FormControl('', Validators.required)
        this.AppForms = new FormGroup({
            ProcessMasterName: this.ProcessMasterName,
            ProductID: this.ProductID
        })
    }
    GetProductType() {
        this.product.GetProductTypes().subscribe(data => {
            this.prodList = data;
        })
    }
    GetProcessMaster() {
        this.processMasterService.GetProcessMaster().subscribe(data => {
            this.ProcessList = data;
        })
    }
    SubmitForm() {
        this.isFormSubmiting = true;
        const labEmp: any = {
            processName: this.ProcessMasterName.value,
            ProductID: this.ProductID.value
        }
        this.processMasterService.CreateProcessMaster(labEmp).subscribe(data => {
            this.response = data;
            this.isFormSubmiting = false;
            if (this.response.isSuccess) {
                this.AppForms.reset();
                this.GetProcessMaster();
            }
        })
    }
}