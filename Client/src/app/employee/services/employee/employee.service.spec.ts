import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Employee } from '../../models/employee';
import { Image } from '../../models/image';
import { EmployeeService } from './employee.service';

describe('EmployeeService', () => {
  let service: EmployeeService;
  let httpMock: HttpTestingController;
  const emptyEmployee: Employee = new Employee(
    '',
    '',
    new Image('', 0),
    '',
    '',
    new Date()
  );
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EmployeeService],
    });
    service = TestBed.inject(EmployeeService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should Post', () => {
    service.post(emptyEmployee).subscribe((posts) => {
      expect(posts).toBeTruthy();
    });

    const request = httpMock.expectOne(`${service.url}`);
    expect(request.request.method).toBe('POST');
    const resp = emptyEmployee;
    resp.id = 0;
    request.flush(resp);
  });

  it('should Get', () => {
    const id: number = 0;
    service.get(id).subscribe((posts) => {
      expect(posts).toBeTruthy();
    });

    const request = httpMock.expectOne(`${service.url}/${id}`);
    expect(request.request.method).toBe('GET');
    const resp = emptyEmployee;
    resp.id = id;
    request.flush(resp);
  });

  it('should GetAll', () => {
    service.getAll().subscribe((posts) => {
      expect(posts).toBeTruthy();
    });

    const request = httpMock.expectOne(`${service.url}`);
    expect(request.request.method).toBe('GET');
    const resp = emptyEmployee;
    resp.id = 0;
    request.flush([resp]);
  });

  it('should Put', () => {
    service.put(emptyEmployee).subscribe((posts) => {
      expect(posts).toBeTruthy();
    });

    const request = httpMock.expectOne(`${service.url}`);
    expect(request.request.method).toBe('PUT');
    const resp = emptyEmployee;
    resp.id = 0;
    request.flush(resp);
  });

  it('should Delete', () => {
    const id: number = 0;
    service.delete(id).subscribe((posts) => {
      expect(posts).toBeTruthy();
    });

    const request = httpMock.expectOne(`${service.url}/${id}`);
    expect(request.request.method).toBe('DELETE');
    const resp = emptyEmployee;
    resp.id = id;
    request.flush(resp);
  });
});
