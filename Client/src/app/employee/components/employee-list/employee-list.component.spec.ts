import { CommonModule } from '@angular/common';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../../services/employee/employee.service';
import { Image } from '../../models/image';
import { EmployeeListComponent } from './employee-list.component';

describe('EmployeeListComponent', () => {
  let component: EmployeeListComponent;
  let fixture: ComponentFixture<EmployeeListComponent>;
  let httpMock: HttpTestingController;
  let service: EmployeeService;

  const emptyEmployee: Employee = new Employee(
    'id',
    '',
    new Image('', 0),
    '',
    '',
    new Date()
  );

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        CommonModule,
        HttpClientTestingModule,
        FormsModule
      ],
      declarations: [ EmployeeListComponent ],
      providers: [EmployeeService],
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    httpMock = TestBed.inject(HttpTestingController);
    service = TestBed.inject(EmployeeService);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('shouldFilter', () => {
    const request = httpMock.expectOne(`${service.url}`);
    expect(request.request.method).toBe('GET');
    const resp = emptyEmployee;
    resp.id = 0;
    request.flush([resp]);
    component.filter = 'id';
    component.search();
    expect(component.employees).toBeTruthy();
  });

  it('shouldFilterNotFound', () => {
    const request = httpMock.expectOne(`${service.url}`);
    expect(request.request.method).toBe('GET');
    const resp = emptyEmployee;
    resp.id = 0;
    request.flush([resp]);
    component.filter = 'id787';
    component.search();
    expect(component.modalRefDialog.title).toBe('Error');
  });

  it('shouldFilterEmptyResponse', () => {
    const request = httpMock.expectOne(`${service.url}`);
    expect(request.request.method).toBe('GET');
    request.flush([]);
    component.filter = 'id787';
    component.search();
    expect().nothing();
  });

  it('should open a modal', () => {
    emptyEmployee.id = 1;
    component.open(emptyEmployee);
    expect(component.modalRef.employee.id).toBe(emptyEmployee.id);
  });
});
