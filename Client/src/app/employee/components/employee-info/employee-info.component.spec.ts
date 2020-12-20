import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DialogInformationComponent } from 'src/app/core/components/dialog-information/dialog-information.component';
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
  let modalService: NgbModal;

  const emptyEmployee: Employee = new Employee(
    'id',
    'Fran',
    new Image('', 1),
    '+(506)8888-8888',
    'email@gmail.com',
    new Date(),
    '',
    1
  );

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports:[
        HttpClientTestingModule,
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
    modalService = TestBed.inject(NgbModal);
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

  it('should update with missing parameteres', () => {
    const resp = emptyEmployee;
    resp.managerId = 'id';
    resp.id = 1;
    component.formValues.patchValue({
      employeeId: resp.employeeId,
      name: resp.name,
      phone: resp.phoneNumber,
      email: resp.email,
      hire: resp.hireDate,
      managerId: resp.employeeId
    })
    component.formValues.markAllAsTouched();
    component.update();
    const request = httpMock.expectOne(`${eService.url}`);
    expect(request.request.method).toBe('PUT');

    request.flush([resp]);
    expect(component.modalRef.title).toBe('Success!');
  });

  it('should delete', async () => {
    component.modal = modalService.open(DialogInformationComponent, {
      centered: true,
      size: 'sm',
    });
    component.modal.close();
    spyOn(component,'closeValue').and
    .resolveTo(true);
    const resp = emptyEmployee;
    resp.managerId = 'id';
    resp.id = 1;
    await component.deleteEmp();

    const request = httpMock.expectOne(`${eService.url}/${component.employee.id}`);
    expect(request.request.method).toBe('DELETE');

    request.flush([resp]);
    expect(component.modalRef.title).toBe('Success!');
  });

  it('should not delete', async () => {
    component.modal = modalService.open(DialogInformationComponent, {
      centered: true,
      size: 'sm',
    });
    component.modal.close();
    spyOn(component,'closeValue').and
    .resolveTo(false);
    const resp = emptyEmployee;
    resp.managerId = 'id';
    resp.id = 1;
    await component.deleteEmp();

    expect().nothing();
  });
});
