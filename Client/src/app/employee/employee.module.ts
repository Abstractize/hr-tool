import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { ImageService } from './services/image/image.service';
import { EmployeeService } from './services/employee/employee.service';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeRoutingModule } from './employee-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeeInfoComponent } from './components/employee-info/employee-info.component';
import { NgbDatepickerModule, NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-bootstrap-spinner';



@NgModule({
  declarations: [
    AddEmployeeComponent,
    EmployeeListComponent,
    EmployeeInfoComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    EmployeeRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    NgbModalModule,
    NgbDatepickerModule,
    NgxSpinnerModule
  ],
  providers: [
    ImageService,
    EmployeeService
  ]
})
/**
 * Module that contains all the employee related components.
 */
export class EmployeeModule { }
