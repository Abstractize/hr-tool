import { CommonModule } from '@angular/common';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { Employee } from '../../models/employee';
import { Image } from '../../models/image';
import { EmployeeService } from '../../services/employee/employee.service';
import { ImageService } from '../../services/image/image.service';

import { AddEmployeeComponent } from './add-employee.component';

describe('AddEmployeeComponent', () => {
  let component: AddEmployeeComponent;
  let fixture: ComponentFixture<AddEmployeeComponent>;
  let httpMock: HttpTestingController;
  let eService: EmployeeService;
  let iService: ImageService;

  const emptyEmployee: Employee = new Employee(
    'id',
    'Fran',
    new Image('', 1),
    '+(506)8888-8888',
    'email@gmail.com',
    new Date()
  );

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        CommonModule,
        HttpClientTestingModule,
        FormsModule,
        RouterTestingModule.withRoutes([]),
        ReactiveFormsModule
      ],
      declarations: [AddEmployeeComponent],
      providers: [EmployeeService, ImageService],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    httpMock = TestBed.inject(HttpTestingController);
    eService = TestBed.inject(EmployeeService);
    iService = TestBed.inject(ImageService);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('shouldPost', () => {
    const resp = emptyEmployee;
    resp.id = 0;
    component.imageValue = resp.picture;
    component.formValues.patchValue({
      employeeId: resp.employeeId,
      name: resp.name,
      phone: resp.phoneNumber,
      email: resp.email,
      hire: resp.hireDate
    })
    component.formValues.markAllAsTouched();
    component.formValues.clearValidators();

    component.formValues.updateValueAndValidity();
    component.onSubmit();
    const request = httpMock.expectOne(`${eService.url}`);
    expect(request.request.method).toBe('POST');
    request.flush(resp);
  });

  it('shouldNotPost', () => {
    component.onSubmit();
    expect().nothing();
  });

  it('should select the file', () => {
    let blob = new Blob([""], { type: 'image/png' });
    blob["lastModifiedDate"] = "";
    blob["name"] = "image";

    let fakeF = <File>blob;

    const event = {target:{files: [fakeF]}};
    component.onFileSelected(event);
    const request = httpMock.expectOne(`${iService.url}`);
    expect(request.request.method).toBe('POST');
    const resp = emptyEmployee.picture;
    request.flush(resp);
  });

  it('should post with Manager', () => {
    const resp = emptyEmployee;
    resp.id = 0;
    component.imageValue = resp.picture;
    component.formValues.patchValue({
      employeeId: resp.employeeId,
      name: resp.name,
      phone: resp.phoneNumber,
      email: resp.email,
      hire: resp.hireDate,
      managerId: resp.employeeId
    })
    component.formValues.markAllAsTouched();
    component.formValues.clearValidators();

    component.formValues.updateValueAndValidity();
    component.onSubmit();
    const request = httpMock.expectOne(`${eService.url}`);
    expect(request.request.method).toBe('POST');
    request.flush(resp);
  });
});
