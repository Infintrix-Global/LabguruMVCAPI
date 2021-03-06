import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { IResponce } from "src/app/Shared/responce.model";
import { IProductType } from "./Shared/productType.model";
import { ProductTypeService } from "./Shared/ProductType.service";
declare var $: any;
@Component({

    selector: 'wa-login',
    templateUrl: './ProductType.component.html'
})

export class ProductTypeComponent implements OnInit {
    productlist!: IProductType[]
    SavedImagePath: string = '';
    ProductTypeForm!: FormGroup
    ProductTypeName!: FormControl;
    mouseover_form: boolean = false;
    isImpressionmindatory: boolean = false;
    formSubmitData = new FormData();
    constructor(private PTS: ProductTypeService) { }
    response !: IResponce;
    ngOnInit() {
        $('.dropify').dropify();
        this.getProductType();


        this.ProductTypeName = new FormControl('', Validators.required)
        this.ProductTypeForm = new FormGroup({
            ProductTypeName: this.ProductTypeName
        })
    }

    isImpressionUpload(data: any) {
        this.isImpressionmindatory = data.checked;
    }
    getProductType() {
        this.PTS.GetProductTypes().subscribe(data => {
            this.productlist = data;
        })
    }
    isImpression(impressdata: boolean) {
        if (impressdata)
            return 'YES'
        else
            return 'NO'

    }
    fileToUpload!: File;
    imageChanged(data: any) {
        if (data.target.files.length > 0) {
            this.formSubmitData = new FormData();;
            var files = data.target.files;
            this.fileToUpload = files.item(0);
            this.formSubmitData.append('formFiles', this.fileToUpload, this.fileToUpload.name);
        }
    }
    CreateProduct() {
        if (this.ProductTypeForm.valid) {

            this.formSubmitData.append("ProductTypeName", this.ProductTypeName.value);
            this.formSubmitData.append("isImpressionMindatory", this.isImpressionmindatory.toString());
            this.PTS.CreateProduct(this.formSubmitData).subscribe(data => {
                this.response = data;
                if (data.isSuccess) {
                    this.getProductType();
                    this.ProductTypeForm.reset();
                }
                console.log(this.response)
            });
        }
    }

    ValidateProductname() {
        return (this.ProductTypeName.valid || this.ProductTypeName.untouched);
    }
}