import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from '../../models/employee';
import { Image } from '../../models/image';
import { EmployeeService } from '../../services/employee/employee.service';
import { ImageService } from '../../services/image/image.service';

import { EmployeeInfoComponent } from './employee-info.component';

describe('EmployeeInfoComponent', () => {
  let component: EmployeeInfoComponent;
  let fixture: ComponentFixture<EmployeeInfoComponent>;
  let httpMock: HttpTestingController;
  let eService: EmployeeService;
  let iService: ImageService;

  const emptyEmployee: Employee = new Employee(
    'id',
    'Fran',
    new Image('', 1),
    '+(506)8888-8888',
    'email@gmail.com',
    new Date(),
    'id',
    0
  );

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports:[
        HttpClientTestingModule,
        RouterTestingModule.withRoutes([]),
      ],
      declarations: [ EmployeeInfoComponent ],
      providers: [NgbActiveModal, ImageService]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeInfoComponent);
    component = fixture.componentInstance;
    component.employee = emptyEmployee;
    fixture.detectChanges();
    httpMock = TestBed.inject(HttpTestingController);
    eService = TestBed.inject(EmployeeService);
    iService = TestBed.inject(ImageService);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
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

  it('should update not update', () => {
    component.update();
    expect(component.modalRef.title).toBe('Fail');
  });

  it('should update', () => {
    component.formValues.markAllAsTouched();
    component.update();
    const request = httpMock.expectOne(`${eService.url}`);
    expect(request.request.method).toBe('PUT');
    const resp = emptyEmployee;
    request.flush([resp]);
    expect(component.modalRef.title).toBe('Success!');
  });
});
