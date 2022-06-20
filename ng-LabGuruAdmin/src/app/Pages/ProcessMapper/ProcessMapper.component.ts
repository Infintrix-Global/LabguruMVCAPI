import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ILaboratory } from "src/app/MasterSection/Laboratory/Shared/laboratory.model";
import { LaboratoryService } from "src/app/MasterSection/Laboratory/Shared/laboratory.service";
import { LabEmployeeService } from "src/app/MasterSection/LaboratoryEmployee/Shared/LabEmployee.service";
import { IProcessMaster } from "src/app/MasterSection/ProcessMaster/Shared/ProcessMaster.model";
import { ProcessMasterService } from "src/app/MasterSection/ProcessMaster/Shared/ProcessMaster.service";
import { IProductType } from "src/app/MasterSection/ProductType/Shared/productType.model";
import { ProductTypeService } from "src/app/MasterSection/ProductType/Shared/ProductType.service";
import { IResponce } from "src/app/Shared/responce.model";
import { ProcessMapperService } from "./Shared/ProcessMapper.service";

@Component({
    templateUrl: './ProcessMapper.component.html'
})

export class ProcessMapperComponent implements OnInit {
    responce !: IResponce;
    AppForms !: FormGroup;
    LabID!: FormControl;
    LabEmployeeID !: FormControl
    ProductTypeID !: FormControl
    ProcessID !: FormControl;
    mouseover_form: boolean = false;
    ProcessMapList !: any[]
    labList !: ILaboratory[]
    prodList !: IProductType[];
    processList !: IProcessMaster[];
    labempList !: any[]
    constructor(private processMapperService: ProcessMapperService, private labService: LaboratoryService, private productService: ProductTypeService, private processMaster: ProcessMasterService, private labEmpService: LabEmployeeService) { }
    ngOnInit(): void {
        this.GetProcessMapper();
        this.AppFormInit();
        this.GetLabList();
        this.GetProductType();
        //this.GetProcessMaster();
    }
    AppFormInit() {
        this.LabID = new FormControl('', Validators.required)
        this.LabEmployeeID = new FormControl('', Validators.required)
        this.ProductTypeID = new FormControl('', Validators.required)
        this.ProcessID = new FormControl('', Validators.required)
        this.AppForms = new FormGroup({
            LabID: this.LabID,
            LabEmployeeID: this.LabEmployeeID,
            ProductTypeID: this.ProductTypeID,
            ProcessID: this.ProcessID,

        });
    }
    SubmitForm() {
        if (this.AppForms.valid) {
            const procesMapper = {
                "ProductTypeID": this.ProductTypeID.value,
                "ProcessID": this.ProcessID.value,
                "LabID": this.LabID.value,
                "LabEmployeeID": this.LabEmployeeID.value,
                "IsActive": true
            }
            this.processMapperService.CreateProcessMapper(procesMapper).subscribe(data => {
                this.responce = data;
                if (data.isSuccess) {
                    this.AppForms.reset();
                    this.GetProcessMapper();
                }
            })
        }
    }
    GetLabList() {
        this.labService.Getlaboratory().subscribe(data => {
            this.labList = data;
        })
    }
    GetProductType() {
        this.productService.GetProductTypes().subscribe(data => {
            this.prodList = data;
        })
    }
    GetProcessMapper() {
        this.processMapperService.GetProcessMapper().subscribe(data => {
            this.ProcessMapList = data;
        })
    }
    GetProcessMaster(productID: any) {
        this.processMaster.GetProcessMasterByProductID(productID).subscribe(data => {
            this.processList = data;
        })
    }
    GetEmployee(data: any) {
        this.labEmpService.GetLabEmployee(data).subscribe(data => {
            console.log(data);
            this.labempList = data;
        })

    }
}