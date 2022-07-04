import { Component, OnInit } from "@angular/core";
import { DoctorService } from "../Shared/doctor.service";

@Component({
    templateUrl: './doctorlis.component.html'
})
export class DoctorListComponent implements OnInit {
    DoctorList !: any[]
    constructor(private doctorService: DoctorService) { }
    ngOnInit() {
        this.GetDoctorList();
    }
    GetDoctorList() {
        this.doctorService.GetDoctors().subscribe(data => {
            this.DoctorList = data;
        })
    }
}