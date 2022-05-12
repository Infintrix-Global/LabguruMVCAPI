import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
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
    constructor(private PTS: ProductTypeService) { }

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
            var files = data.target.files;
            this.fileToUpload = files.item(0);
            const formData = new FormData();
            formData.append('files', this.fileToUpload, this.fileToUpload.name);

            console.log(formData, this.fileToUpload.name, this.fileToUpload)
            this.PTS.UploadImage(formData).subscribe((d) => {
                if (d) {
                    console.log(d.data[0])
                    this.SavedImagePath = d.data[0];
                }
            })
        }
    }
    CreateProduct() {
        if (this.ProductTypeForm.valid) {
            const productType: IProductType = {
                CreatorIP: 'test',
                UpdatorIP: 'test',
                isImpressionMindatory: this.isImpressionmindatory,
                productTypeImagePath: this.SavedImagePath,
                productTypeName: this.ProductTypeName.value
            }
            this.PTS.CreateProduct(productType).subscribe(data => {
                console.log(data);
                if (data.isSuccess) {
                    this.getProductType();
                }
            });
        }
    }

    ValidateProductname() {
        return (this.ProductTypeName.valid || this.ProductTypeName.untouched);
    }
}