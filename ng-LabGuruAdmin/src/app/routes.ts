import { Routes } from "@angular/router";
import { LoginComponent } from "./Authentication/Login/login.component";
import { DashboardComponent } from "./Dashboard/dashboard.component";
import { LabboratoryComponent } from "./MasterSection/Laboratory/laboraroty.component";
import { LabEmployeeComponent } from "./MasterSection/LaboratoryEmployee/labemp.component";
import { ProcessMasterComponent } from "./MasterSection/ProcessMaster/processmaster.component";
import { ProductTypeComponent } from "./MasterSection/ProductType/ProductType.component";
import { DoctorComponent } from "./Pages/Doctor/CreateDoctor/doctor.component";
import { LabMappingComponent } from "./Pages/Doctor/DoctorLabMap/LabMap.component";
import { ProcessMapperComponent } from "./Pages/ProcessMapper/ProcessMapper.component";
import { SubProcessCompaonent } from "./Pages/SubProcess/Subprocess.component";
import { SubProcessEmployeeComponent } from "./Pages/SubProcessEmployee/SubProcEmp.component";
import { AuthGuard } from "./Shared/auth.guard";
export const appRoutes: Routes = [
    { path: '\dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
    { path: '\producttype', component: ProductTypeComponent, canActivate: [AuthGuard] },
    { path: '\login', component: LoginComponent },
    { path: '\laboratory', component: LabboratoryComponent, canActivate: [AuthGuard] },
    { path: '\laboratoryemployee', component: LabEmployeeComponent, canActivate: [AuthGuard] },
    { path: '\doctor', component: DoctorComponent, canActivate: [AuthGuard] },
    { path: '\processmaster', component: ProcessMasterComponent, canActivate: [AuthGuard] },
    { path: '\ProcessMapper', component: ProcessMapperComponent, canActivate: [AuthGuard] },
    { path: '\SubProcess', component: SubProcessCompaonent, canActivate: [AuthGuard] },
    { path: '\SubProcessEmployee', component: SubProcessEmployeeComponent, canActivate: [AuthGuard] },
    { path: '\LabMap', component: LabMappingComponent, canActivate: [AuthGuard] },
    { path: '', redirectTo: '', pathMatch: 'full', component: DashboardComponent, canActivate: [AuthGuard] },

    // {
    //     path: 'student',
    //     loadChildren: () => import('./Approot/Student/student.module')
    //         .then(t => t.StudentModule)
    // }
]
