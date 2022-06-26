import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { appRoutes } from './routes';
import { HeaderComponent } from './Layout/Header/header.component';
import { sidebarComponent } from './Layout/Sidebar/sidebar.component';
import { ProductTypeService } from './MasterSection/ProductType/Shared/ProductType.service';
import { ProductTypeComponent } from './MasterSection/ProductType/ProductType.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './Authentication/Login/login.component';
import { AuthenticationService } from './Authentication/Shared/authentication.service';
import { LabboratoryComponent } from './MasterSection/Laboratory/laboraroty.component';
import { LaboratoryService } from './MasterSection/Laboratory/Shared/laboratory.service';


import { LabEmployeeComponent } from './MasterSection/LaboratoryEmployee/labemp.component';
import { ProcessMasterComponent } from './MasterSection/ProcessMaster/processmaster.component';
import { ProcessMasterService } from './MasterSection/ProcessMaster/Shared/ProcessMaster.service';
import { DashboardComponent } from './Dashboard/dashboard.component';
import { ProcessMapperComponent } from './Pages/ProcessMapper/ProcessMapper.component';
import { ProcessMapperService } from './Pages/ProcessMapper/Shared/ProcessMapper.service';
import { SubProcessCompaonent } from './Pages/SubProcess/Subprocess.component';
import { SubProcessService } from './Pages/SubProcess/Shared/Subprocess.service';
import { SubProcessEmployeeComponent } from './Pages/SubProcessEmployee/SubProcEmp.component';
import { SubProcessEmpService } from './Pages/SubProcessEmployee/Shared/subprocessemp.service';
import { AuthGuard } from './Shared/auth.guard';
import { DoctorComponent } from './Pages/Doctor/CreateDoctor/doctor.component';
import { DoctorService } from './Pages/Doctor/Shared/doctor.service';
import { LabMappingComponent } from './Pages/Doctor/DoctorLabMap/LabMap.component';
import { RoleService } from './Shared/Role/role.service';
import { LabEmployeeService } from './Shared/LaboratoryEmployee/LabEmployee.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    sidebarComponent,
    ProductTypeComponent,
    LoginComponent,
    LabboratoryComponent,
    DoctorComponent,
    LabEmployeeComponent,
    ProcessMasterComponent,
    DashboardComponent,
    ProcessMapperComponent,
    SubProcessCompaonent,
    SubProcessEmployeeComponent,
    LabMappingComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule
  ],
  providers: [ProductTypeService, SubProcessEmpService, DoctorService, SubProcessService, ProcessMapperService, LabEmployeeService, ProcessMasterService, AuthenticationService, LaboratoryService, AuthGuard,
    RoleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
