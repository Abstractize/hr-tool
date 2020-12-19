import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { ImageService } from './services/image/image.service';
import { EmployeeService } from './services/employee/employee.service';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeRoutingModule } from './employee-routing.module';



@NgModule({
  declarations: [
    AddEmployeeComponent,
    EmployeeListComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    EmployeeRoutingModule
  ],
  providers: [
    ImageService,
    EmployeeService
  ],
  exports: [
    EmployeeListComponent,
    AddEmployeeComponent
  ]
})
export class EmployeeModule { }
